using DiscordBot.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace DiscordBot.APIs
{
    //Medium verilerini veren uygun bir api kaynağı bulunamadığı için bu sınıf kullanılmayacak.
    public class MediumAPI 
    {
        //private readonly RestClient _client;
        //private readonly ConfigJSON _configJson;
        //public string _baseUrl { get; set; }
        //public MediumAPI(string baseUrl)
        //{
        //    _client = new RestClient(baseUrl);
        //    _baseUrl = baseUrl;
        //    //deseriliaze json
        //    var json = string.Empty;
        //    using (var fs = File.OpenRead("C:\\config.json"))
        //    using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
        //    json = sr.ReadToEnd();
            
        //    _configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);
        //}
        //public string Get(string endpoint)
        //{
        //    endpoint = endpoint + _configJson.Medium_userid + "/publications";
        //    var request = new RestRequest(_baseUrl+endpoint, Method.Get);
        //    request.AddHeader("Accept", "application/json");
        //    request.AddHeader("Authorization", _configJson.Medium_token);
        //    var response = _client.Execute(request);

        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //       var data = response.Content;
        //       return data;
        //    }
        //    else
        //    {
        //        // Handle error cases here
        //        return null;
        //    }
        //}
    }

    //public class MediumAPIModel
    //{
    //    public string title { get; set; }
    //    public string link { get; set; }
    //    public string author { get; set; }
    //    public double published { get; set; }
    //    public double created { get; set; }
    //    public List<string> category { get; set; }
    //    public string content { get; set; }
    //}

}
