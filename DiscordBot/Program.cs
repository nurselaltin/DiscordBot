
using DiscordBot.APIs;

namespace DiscordBot
{
  internal class Program
  {
    static void Main(string[] args)
    {

      var bot = new DiscordBot();
      bot.RunAsyc().GetAwaiter().GetResult();

      //var api = new MediumAPI("https://api.medium.com/v1/");
      //api.Get("users/");

      Console.ReadLine();
    }
  }
}