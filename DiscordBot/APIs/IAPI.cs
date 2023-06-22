using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.APIs
{
    public interface IAPI
    {
        string Get(string endpoint);
    }
}
