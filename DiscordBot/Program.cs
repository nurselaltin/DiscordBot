
using DiscordBot.APIs;

namespace DiscordBot
{
  internal class Program
  {
    static void Main(string[] args)
    {

      //var bot = new DiscordBot();
      //bot.RunAsyc().GetAwaiter().GetResult();

      var youtube = new YoutubeAPI("https://youtube.googleapis.com/youtube/v3/");
      youtube.Get("subscriptions");


      Console.ReadLine();
    }
  }
}