using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Context
{
    public class DiscordBotContext : DbContext  
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string jsonEnviroment = string.Empty;
            jsonEnviroment = "C:\\mts\\connectionstring.json";
            settingFile account = JsonConvert.DeserializeObject<settingFile>(File.ReadAllText(jsonEnviroment));
            optionsBuilder.UseSqlServer(account.DBConString);
        }

        public DbSet<DiscordLog> Logs { get; set; }
        public DbSet<Link> Links { get; set; }
    }

    public class settingFile
    {
        public string DBConString { get; set; }
    }
}
