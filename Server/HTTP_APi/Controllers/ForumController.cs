using HTTP_APi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;



        public ForumController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            KnowledgeCenter.getInstance().topics.Add(new Topic(0, new DateTime(), "Добро пожаловать на форум!", "Owner"));
        }

        [HttpGet]
        public List<Topic> Get()
        {
            return TopicGetDTO.FromTopics(KnowledgeCenter.getInstance().topics);
        }
        [HttpGet("{id}")]
        public Topic GettTopic([FromRoute] int id)
        {
            KnowledgeCenter knowledgeCenter = KnowledgeCenter.getInstance();
            for (int i = 0; i < knowledgeCenter.topics.Count; i++)
            {
                if (knowledgeCenter.topics[i].id == id)
                {
                    return knowledgeCenter.topics[i];
                }

            }
            HttpContext.Response.StatusCode = 404;
            return new Topic(-1, new DateTime(), "Неверный номер темы!", "Creator");
        }
        [HttpPost]
        public Topic CreateNew([FromBody] NewTopicDTO body)
        {
            KnowledgeCenter knowledgeCenter = KnowledgeCenter.getInstance();
            knowledgeCenter.topics.Add(new Topic(knowledgeCenter.GetNextId(), DateTime.UtcNow, body.Title, body.Name));
            return knowledgeCenter.topics[knowledgeCenter.topics.Count-1];
        }
        [HttpPost("{id}")]
        public Post CreateNewPost([FromBody] NewPostDTO body)
        {
            KnowledgeCenter knowledgeCenter = KnowledgeCenter.getInstance();
            Topic topic = knowledgeCenter.topics[body.TopicId];
            topic.Posts.Add(new Post(topic.GetNextId(),DateTime.UtcNow,body.Message,body.Name));
            return topic.Posts[topic.Posts.Count - 1];
        }
    }
}
