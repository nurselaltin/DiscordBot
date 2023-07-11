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
      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      LogService.SaveLog(link);
    }

    [Command("youtube")]
    public async Task YoutubeVideoCommand(CommandContext ctx)
    {
      var member = ctx.Member;
      //Üyeye daha önce önerildi mi?Bir daha önerme
      var link = YoutubeService.GetYoutubeVideoLink(member.DisplayName);
      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      Console.WriteLine(member);
      LogService.SaveLog(link);
    }
  }
}
