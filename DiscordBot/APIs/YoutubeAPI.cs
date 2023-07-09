using Data.Entity;
using DataAccess.Concrete;
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

            List<Link> videos = new List<Link>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            searchListResponse.Items = searchListResponse.Items.Where(x => x.Id.Kind == "youtube#video").OrderBy(x => x.Snippet.PublishedAt).ToList();
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":

                        var entity = new Link()
                        {
                            AccountName = channelName,
                            TypeLink = 1,
                            LinkAddress = String.Format("https://www.youtube.com/embed/{0}", searchResult.Id.VideoId),
                            CreatedDate = DateTime.Now,
                        };
                        videos.Add(entity);
                        break;

                        //case "youtube#channel":
                        //    channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        //    break;

                        //case "youtube#playlist":
                        //    playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        //    break;
                }
            }

            //Save Db
            if (videos.Count() > 0)
            {
                var dal = new LinkDal();
                foreach (var link in videos)
                {
                    var res = dal.Find((c => c.LinkAddress.Equals(link) && c.TypeLink == 1 && c.IsDeleted == false));
                    if (res != null)
                        continue;
                    dal.Add(link);
                }
           
            }

            //Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
        }
    }
}
