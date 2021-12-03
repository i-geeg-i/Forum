using System;

namespace HTTP_APi
{
    public class Post
    {
        public int Id { get; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public Post(int id, DateTime date, string post, string name)
        {
            this.Id = id;
            this.Date = date;
            this.Message = post;
            this.Name = name;
        }
    }
}
