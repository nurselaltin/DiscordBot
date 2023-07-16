using Data.Entity;
using DataAccess.Concrete;
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
       var linkDal = new DiscordLogDal();
       List<DiscordLog> links = linkDal.ToList(x => x.IsDeleted == false).OrderByDescending(x => x.ID).ToList();

       foreach (var item in links)
       {
           var model = new DiscordLogModel();
           model.OrderNo = item.ID.ToString();
           model.AccountName = item.AccountName;
           model.TypeLink = item.TypeLink == 0 ? "medium" : "youtube";
           model.DateTime = item.CreatedDate.ToString();
           model.Link = item.Link;
           model.Log = item.TypeLink == 0 ? "Medium makale link önerisi yapıldı." : "Youtube içerik önerisi yapıldı.";
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