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
        public static TopicGetDTO FromTopic(Topic topic)
        {
            TopicGetDTO getDTO = new TopicGetDTO();
            getDTO.Id = topic.Id;
            getDTO.Date = topic.Date;
            getDTO.Title = topic.Title;
            getDTO.Name = topic.Name;
            return getDTO;
        }
        public static List<TopicGetDTO> FromTopics(List<Topic> topics)
        {
            List<TopicGetDTO> topicGets = new List<TopicGetDTO>();
            for(int i =0; i < topics.Count; i++)
            {
                topicGets.Add(TopicGetDTO.FromTopic(topics[i]));
            };
            return topicGets;
        }
    }
}
