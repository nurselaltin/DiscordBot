using RestSharp;
using System.Text.Json;

namespace DiscordBot.APIs
{
    public class YoutubeAPI : IAPI
    {
        private readonly RestClient _client;

        public YoutubeAPI(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }
        public string Get(string endpoint)
        {
            var link = "";
            var request = new RestRequest(endpoint, Method.Get);
            //request.AddParameter("q", "MurattYucedag");
            
            request.AddParameter("part", "snippet");
            request.AddParameter("part", "contentDetails");
            request.AddParameter("mine", 1);
            //request.AddParameter("key", "");

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string res = response.Content;
                var model = JsonSerializer.Deserialize<List<MediumAPIModel>>(res);
                link = model.OrderByDescending(x => x.created).FirstOrDefault().link;
                return link;
            }

            return link;
        }
    }
}
