using DiscordBot.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace DiscordBot.APIs
{
    public class ChatGPTAPI
    {
        private readonly RestClient _client;
        private readonly ConfigJSON _configJson;
        public ChatModel _chat { get; set; }
        public ChatGPTAPI()
        {
            _client = new RestClient("https://api.openai.com/v1/chat/" );
         
            //deseriliaze json
            var json = string.Empty;
            using (var fs = File.OpenRead("C:\\config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = sr.ReadToEnd();
            
            _configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            _chat = new ChatModel()
            {
              model = "gpt-3.5-turbo",
              messages = new List<Message>()
            };
            _chat.messages = new List<Message>();
        }
        public string Post(string content)
        {
            var choices = "";
            // Create a new RestRequest instance with the desired HTTP method and resource path
            var req = new RestRequest("completions", Method.Post);
            _chat.messages.Add(new Message() { role = "user", content = content });
            
            req.AddBody(JsonConvert.SerializeObject(_chat));
            
            // Add headers to the request
            req.AddHeader("Authorization", "Bearer " + _configJson.Chatgpt_token);
            req.AddHeader("Content-Type", "application/json");
            
            // Execute the request and get the response
            var res = _client.Execute(req);
            
            // Handle the response
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
              // Do something with the response data
              var responseData = res.Content;
            
              var yy = JsonConvert.DeserializeObject<dynamic>(responseData).choices[0];
              choices = yy.message.content;
            
            }
            else
            {
              // Handle the error
              var errorResponse = res.Content;
            }
            
            return choices;
        }
    }
    public class ChatModel
    {
      public string model { get; set; }
      public List<Message> messages { get; set; }
    }
    public class Message
    {
      public string role { get; set; }
      public string content { get; set; }
    }
    
}
