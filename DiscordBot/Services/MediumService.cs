
namespace DiscordBot.Services
{
    public  class MediumService
    {
        public static string GetArticleLink()
        {
          var links = File.ReadAllLines("D:\\medium_links.txt");
          var rnd = new Random();
          var index = rnd.Next(links.Count());
          string link = links[index];

          return link;
        }
    }
}
