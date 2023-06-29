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
      

      var lines = File.ReadAllLines("D:\\DiscordBot\\discord_log.txt");
      foreach (string line in lines) { 
        logs.Add(line);
      }
      var index = logs.Count;
      string log = $"{index}###{dateTime}###{link}###{dateTime} tarihinde medium makale link({link}) önerildi.";
      logs.Add(log);

      File.WriteAllLines("D:\\DiscordBot\\discord_log.txt", logs);
    }
  }
}
