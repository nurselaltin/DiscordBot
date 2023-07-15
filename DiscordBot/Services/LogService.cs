using Data.Entity;
using DataAccess.Concrete;

namespace DiscordBot.Services
{
  public class LogService
  {
    public static void SaveLog(Link link, string member)
    {
      var dal = new DiscordLogDal();
      var isLinkExist = dal.Find((c => c.Link.Equals(link) && c.TypeLink == 0 && c.IsDeleted == false));

      if (isLinkExist == null) {
        var entity = new DiscordLog();
        entity.AccountName = link.AccountName;
        entity.Member = member;
        entity.Description = "";
        entity.TypeLink = link.TypeLink;
        entity.IsDeleted = false;
        entity.CreatedDate = DateTime.Now;
        entity.Link = link.LinkAddress;
        dal.Add(entity);  
      }
    }
  }
}
