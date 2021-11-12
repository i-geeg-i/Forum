using System;

namespace HTTP_APi
{
    public class Forum
    {
        public int id { get; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public Forum(int id, DateTime dateTime, string post, string name)
        {
            this.id = id;
            this.Date = dateTime;
            this.Post = post;
            this.Name = name;
        }
    }
}
