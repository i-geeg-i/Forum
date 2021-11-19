using System;

namespace HTTP_APi
{
    public class Post
    {
        public int id { get; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public Post(int id, DateTime dateTime, string post, string name)
        {
            this.id = id;
            this.Date = dateTime;
            this.Message = post;
            this.Name = name;
        }
    }
}
