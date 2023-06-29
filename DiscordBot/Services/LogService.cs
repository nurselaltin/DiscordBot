using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
  public class LogService
  {

    public static void SaveLog(string link)
    {
      DateTime dateTime = DateTime.Now;
      var logs = new List<string>();
      string log = $"{dateTime} tarihinde medium makale link({link})  önerildi. ";

      var lines = File.ReadAllLines("D:\\DiscordBot\\discord_log.txt");
      foreach (string line in lines) { 
        logs.Add(line);
      }
      logs.Add(log);

      File.WriteAllLines("D:\\DiscordBot\\discord_log.txt", logs);
    }
  }
}
