using Newtonsoft.Json;

namespace DiscordBot.Utilities
{
    internal struct ConfigJSON
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("medium_token")]
        public string Medium_token { get; private set; }

        [JsonProperty("medium_baseUrl")]
        public string Medium_baseUrl { get; private set; }

        [JsonProperty("medium_endpoint")]
        public string Medium_endpoint { get; private set; }

        [JsonProperty("medium_userid")]
        public string Medium_userid { get; private set; }
        [JsonProperty("youtube_token")]
        public string Youtube_token { get; private set; }
    }
}
