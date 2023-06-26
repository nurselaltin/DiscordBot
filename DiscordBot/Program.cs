
using DiscordBot.APIs;

namespace DiscordBot
{
  internal class Program
  {
    static void Main(string[] args)
    {

      //var bot = new DiscordBot();
      //bot.RunAsyc().GetAwaiter().GetResult();

      //var api = new MediumAPI("https://api.medium.com/v1/");
      //api.Get("users/");

      while (true) {

        var api = new YoutubeAPI("https://www.googleapis.com/youtube/v3/");
        api.GetSubscriptions("playlists");
      }
      Console.ReadLine();
    }
  }
}