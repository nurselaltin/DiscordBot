
namespace DiscordBot
{
  internal class Program
  {
    static void Main(string[] args)
    {

      var bot = new DiscordBot();
      bot.RunAsyc().GetAwaiter().GetResult();
      Console.ReadLine();
    }
  }
}