
using Data.Entity;
using DataAccess.Concrete;

namespace DiscordBot.Services
{
    public  class YoutubeService
    {
        public static Link GetYoutubeVideoLink(string member)
        {
          var linkDal = new LinkDal();
          var links = linkDal.ToList(x => x.TypeLink == 1 && x.IsDeleted == false);
          var rnd = new Random();
          var index = rnd.Next(links.Count());
          var link = links.FirstOrDefault(x => x.ID == index);

          return link;
        }
    }
}
