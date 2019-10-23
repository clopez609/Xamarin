using Newtonsoft.Json;

namespace Xamarin.Common.Models
{

    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
