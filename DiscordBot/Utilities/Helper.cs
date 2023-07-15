using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Utilities
{
    public class Helper
    {
        public static int GenerateIndex(List<int> suggestedIds, List<int> linksIds)
        {
            var rnd = new Random();
            var index = rnd.Next(linksIds.Last(), linksIds.First());

            if(suggestedIds.Contains(index))
                Helper.GenerateIndex(suggestedIds, linksIds);

            return index;
        }
    }
}
