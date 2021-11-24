using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi.Models
{
    public class TopicGetDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public static Topic FromTopic(Topic topic)
        {
            return new Topic(topic.id, topic.Date, topic.Title, topic.Name);
        }
        public static List<Topic> FromTopic(List<Topic> topics)
        {
            List<Topic> topicGets = new List<Topic>();
            for(int i =0; i < topics.Count; i++)
            {
                topicGets.Add(TopicGetDTO.FromTopic(topics[i]));
            };
            return topicGets;
        }
    }
}
