using DiscordBot.Utilities;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System.Text;

namespace DiscordBot.APIs
{
    public class YoutubeAPI 
    {
        private readonly ConfigJSON _configJson;
        public YoutubeAPI()
        {
           //deseriliaze json
           var json = string.Empty;
           using (var fs = File.OpenRead("C:\\config.json"))
           using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
               json = sr.ReadToEnd();

           _configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);
        }
        //youtube_video_links
        public async Task VideoByChannel(string channelName)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _configJson.Youtube_apiKey,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = channelName; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            searchListResponse.Items = searchListResponse.Items.Where(x => x.Id.Kind == "youtube#video").OrderBy(x => x.Snippet.PublishedAt).ToList();
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                       
                        videos.Add(String.Format("https://www.youtube.com/embed/{0}", searchResult.Id.VideoId));
                        break;

                        //case "youtube#channel":
                        //    channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        //    break;

                        //case "youtube#playlist":
                        //    playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        //    break;
                }
            }
            if (videos.Count() > 0)
            {
                File.WriteAllLines(@"D:\DiscordBot\youtube_video_links.txt", videos);
            }
            Console.WriteLine(String.Format("", string.Join("\n", videos)));
            //Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
        }
    }
}
