using DiscordBot.APIs;
using DiscordBot.Services;
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
      var link = MediumService.GetArticleLink();
      await ctx.Channel.SendMessageAsync(link);
    }



  }
}
