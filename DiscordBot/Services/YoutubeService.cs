
namespace DiscordBot.Services
{
    public  class YoutubeService
    {
        public static string GetYoutubeVideoLink()
        {
          var links = File.ReadAllLines("D:\\DiscordBot\\youtube_video_links.txt");
          var rnd = new Random();
          var index = rnd.Next(links.Count());
          string link = links.Last();

          return link;
        }
    }
}
