using DiscordBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

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
      LogService.SaveLog(link, 0);
    }

    [Command("youtube")]
    public async Task YoutubeVideoCommand(CommandContext ctx)
    {
      var link = YoutubeService.GetYoutubeVideoLink();
      await ctx.Channel.SendMessageAsync(link);
      LogService.SaveLog(link, 1);
    }
  }
}
