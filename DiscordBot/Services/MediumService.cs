
using Data.Entity;
using DataAccess.Concrete;
using DiscordBot.Utilities;
using Google.Apis.YouTube.v3.Data;

namespace DiscordBot.Services
{
    public  class MediumService
    {
        public static Link GetArticleLink(int memberId)
        {
          var mapDal = new UserLinkMapDal();
          var suggestedLinkIDs = mapDal.ToList(x => x.UserId == memberId && x.IsSuggested == true && x.TypeLink == 0).Select(x => x.LinkId).ToList();
          
          var linkDal = new LinkDal();
          var links = linkDal.ToList(x => !suggestedLinkIDs.Contains(x.ID) && x.TypeLink == 0 && x.IsDeleted == false).OrderByDescending(x => x.ID);
          
          var index = Helper.GenerateIndex(suggestedLinkIDs, links.Select(x => x.ID).ToList());
          var link = links.FirstOrDefault(x => x.ID == index);
          
          return link;
        }
    }
}
