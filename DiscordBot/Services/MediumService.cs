
using Data.Entity;
using DataAccess.Concrete;

namespace DiscordBot.Services
{
    public  class MediumService
    {
        public static Link GetArticleLink(string member)
        {
          var linkDal = new LinkDal();
          var links = linkDal.ToList(x => x.TypeLink == 0);
          var rnd = new Random();
          var index = rnd.Next(links.Count());
          var link = links.FirstOrDefault(x => x.ID == index);

          return link;
        }
    }
}
