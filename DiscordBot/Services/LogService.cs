using Data.Entity;
using DataAccess.Concrete;

namespace DiscordBot.Services
{
  public class LogService
  {
    public static void SaveLog(string link, int typeLink)
    {
      var dal = new DiscordLogDal();
      var isLinkExist = dal.Find((c => c.Link.Equals(link) && c.TypeLink == 0 && c.IsDeleted == false));

      if (isLinkExist == null) {
        var entity = new DiscordLog();
        entity.AccountName = "";
        entity.Description = "";
        entity.TypeLink = typeLink;
        entity.IsDeleted = false;
        entity.CreatedDate = DateTime.Now;
        entity.Link = link;
        dal.Add(entity);  
      }
    }
  }
}
