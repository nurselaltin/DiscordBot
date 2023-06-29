namespace DiscordBot.Bots
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var bot = new DiscordBot();
      bot.RunAsyc().GetAwaiter().GetResult();
      //Linkleri doldur
      //var mediumbot = new MediumBot();

      Console.ReadLine();
    }
  }
}