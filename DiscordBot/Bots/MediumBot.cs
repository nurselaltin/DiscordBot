using Data.Entity;
using DataAccess.Concrete;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DiscordBot.Bots
{
  public class MediumBot
  {
    public MediumBot()
    {
        //settings
        //close console
        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        service.HideCommandPromptWindow = true;

        //close browser
        ChromeOptions arg = new ChromeOptions();
        arg.AddArguments("--headless");
       
        IWebDriver driver = new ChromeDriver(service, arg);
        driver.Navigate().GoToUrl("https://medium.com/trendyol-tech");
        var links = new List<Link>();

        var el = driver.FindElements(By.ClassName("row")).ToList();
        foreach (var div in el)
        {
           var divs = div.FindElements(By.ClassName("u-xs-size12of12"));
           foreach (var item in divs)
           {
              string link = item.FindElement(By.ClassName("u-xs-marginBottom10")).FindElement(By.TagName("a")).GetAttribute("href");
              var entity = new Link()
              {
                  AccountName = "trendyol-tech",
                  TypeLink = 0,
                  LinkAddress = link,
                  CreatedDate = DateTime.Now,
              };
              links.Add(entity);
           }
        }

        //Save Db
        if(links.Count() > 0)
        {
          var dal = new LinkDal();
          foreach (var link in links)
          {
             var res = dal.Find((c => c.LinkAddress.Equals(link) && c.TypeLink == 0 && c.IsDeleted == false));
             if(res != null)
               continue;
             dal.Add(link);
          }
          //File.WriteAllLines(@"D:\medium_links.txt", links);
        }

    }
  }
}
