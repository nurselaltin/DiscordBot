using DiscordBot.APIs;

namespace DiscordBot.Bots
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //Choose to resource 
      Console.WriteLine("Choose The Resource : Medium(1) Or Youtube(2) ");
      var resource = Console.ReadLine();
      switch (resource)
      {
         case "1":
             var mediumbot = new MediumBot();
             break;

         case "2":

             Console.WriteLine("Cahannel Name : ");
             var channelName = Console.ReadLine();
             var youtubeApi = new YoutubeAPI();
             youtubeApi.VideoByChannel(channelName);

             break;
      }

      var bot = new DiscordBot();
      bot.RunAsyc().GetAwaiter().GetResult();
      Console.ReadLine();
    }
  }
}