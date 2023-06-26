using DiscordBot.APIs;
using DiscordBot.Utilities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using System.Text;

namespace DSharpPlus.Commands
{
  public class FunCommands : BaseCommandModule
  {
    [Command("test")]
    public async Task TestCommand(CommandContext ctx)
    {
      await ctx.Channel.SendMessageAsync("Hello, How can I go taksim aasghsa");
    }

    [Command("article")]
    public async Task ArticleCommand(CommandContext ctx)
    {
      //deseriliaze json
      var json = string.Empty;
      using (var fs = File.OpenRead("C:\\config.json"))
      using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
      json = await sr.ReadToEndAsync();

      //Medium api değiştirilecek
      var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);
      var medium = new MediumAPI(configJson.Medium_baseUrl);
      var link  = medium.Get(configJson.Medium_endpoint);

      await ctx.Channel.SendMessageAsync(link);
    }



  }
}
