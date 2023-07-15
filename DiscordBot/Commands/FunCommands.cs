using DiscordBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DSharpPlus.Commands
{
  public class FunCommands : BaseCommandModule
  {
    [Command("hello")]
    public async Task TestCommand(CommandContext ctx)
    {
      await ctx.Channel.SendMessageAsync("Hello, çay-kahve bir şeyler ister misin?");
    }

    [Command("article")]
    public async Task ArticleCommand(CommandContext ctx)
    {
      var member = ctx.Member;
      var link = MediumService.GetArticleLink(member.DisplayName);

      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      LogService.SaveLog(link, member.Nickname);
    }

    [Command("youtube")]
    public async Task YoutubeVideoCommand(CommandContext ctx)
    {
      var member = ctx.Member;
      var link = YoutubeService.GetYoutubeVideoLink(member.DisplayName);
     
      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      LogService.SaveLog(link, member.Nickname);
    }
  }
}
