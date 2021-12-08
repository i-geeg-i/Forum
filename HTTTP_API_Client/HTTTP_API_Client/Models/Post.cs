using System;
using System.Text.Json.Serialization;

namespace HTTP_APi
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        public Post(int id, DateTime date, string name, string message)
        {
            this.Id = id;
            this.Date = date;
            this.Name = name;
            this.Message = message;
        }
    }
}
