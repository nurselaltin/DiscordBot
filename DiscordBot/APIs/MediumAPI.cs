using RestSharp;
using System.Text.Json;

namespace DiscordBot.APIs
{
    public class MediumAPI : IAPI
    {
        private readonly RestClient _client;

        public MediumAPI(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }
        public string Get(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string res = response.Content;
                var model = JsonSerializer.Deserialize<List<MediumAPIModel>>(res);
                var link = model.OrderByDescending(x => x.created).FirstOrDefault().link;
                return link;
            }
            else
            {
                // Handle error cases here
                return null;
            }
        }
    }

    public class MediumAPIModel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public double published { get; set; }
        public double created { get; set; }
        public List<string> category { get; set; }
        public string content { get; set; }
    }
}
