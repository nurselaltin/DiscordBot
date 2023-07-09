using DiscordBotLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Unicode;

namespace DiscordBotLog.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var models = new List<DiscordLogModel>();
      var lines = System.IO.File.ReadAllLines("D:\\DiscordBot\\discord_log.txt");

      foreach (string line in lines) {
                
        var str = line.Trim().Split("###");
        var model = new DiscordLogModel();
        model.OrderNo = str[0];
        model.DateTime = str[1];
        model.Link = str[2];
        model.Log = (str[3].Length > 49) ? str[3].Substring(0, 50) : str[3];
        
        models.Add(model);
      }

      return View(models);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}