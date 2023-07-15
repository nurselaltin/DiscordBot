using Core.CommonModel;
using Data.Entity;
using DataAccess.Concrete;
using DiscordBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http.Headers;

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
      var userDal = new UserDal();
      var  user = userDal.GetSingle(x => x.AccountName == member.DisplayName && x.Platform == 2 && x.IsDeleted == false).Data;
      var memberId = user != null ? user.ID: -1;
      if(memberId == -1)
      {
          var entity = new User
          {
              AccountName = member.DisplayName,
              FullName = member.DisplayName,
              UserName = member.DisplayName,
              Platform = 2,
              Password = ""
          };
          userDal.Add(entity);
          memberId = userDal.Find(x => x.AccountName == member.DisplayName && x.Platform == 2 && x.IsDeleted == false).ID;
      }
      var link = MediumService.GetArticleLink(memberId);

      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      LogService.SaveLog(link, member.DisplayName, new UserLinkMap() { UserId = memberId, TypeLink = 0 });
    }

    [Command("youtube")]
    public async Task YoutubeVideoCommand(CommandContext ctx)
    {
      var member = ctx.Member;
      var userDal = new UserDal();
      var  user = userDal.GetSingle(x => x.AccountName == member.DisplayName && x.Platform == 2 && x.IsDeleted == false).Data;
      var memberId = user != null ? user.ID: -1;
      if(memberId == -1)
      {
          var entity = new User
          {
              AccountName = member.DisplayName,
              FullName = member.DisplayName,
              UserName = member.DisplayName,
              Platform = 2,
              Password = ""
          };
          userDal.Add(entity);
          memberId = userDal.Find(x => x.AccountName == member.DisplayName && x.Platform == 2 && x.IsDeleted == false).ID;
      }
      var link = YoutubeService.GetYoutubeVideoLink(memberId);
     
      await ctx.Channel.SendMessageAsync(link.LinkAddress);
      LogService.SaveLog(link, member.DisplayName, new UserLinkMap() { UserId = memberId, TypeLink = 1 });
    }
  }
}
