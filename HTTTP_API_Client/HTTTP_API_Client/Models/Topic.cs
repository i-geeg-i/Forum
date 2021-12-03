using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi.Models
{
    public class Topic
    {
        public int Id { get; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public Topic(int id, DateTime dateTime, string Title, string name)
        {
            this.Id = id;
            this.Date = dateTime;
            this.Title = Title;
            this.Name = name;
            this.Posts = new List<Post>();
        }
        public int GetNextId()
        {
            int id = 0;
            for (int i =0; i < Posts.Count; i++)
            {
                if(Posts[i].Id >= id)
                {
                    id = Posts[i].Id + 1;
                }
            }
            return id;
        }
    }
}
