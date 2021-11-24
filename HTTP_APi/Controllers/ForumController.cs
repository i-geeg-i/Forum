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
            return TopicGetDTO.FromTopic(KnowledgeCenter.getInstance().topics);
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
        public Models.Topic CreateNew([FromQuery] string name, [FromQuery] string title) //I know that I need use DTO!
        {
            KnowledgeCenter knowledgeCenter = KnowledgeCenter.getInstance();
            knowledgeCenter.topics.Add(new Topic(knowledgeCenter.GetNextId(), DateTime.UtcNow, title, name));
            return knowledgeCenter.topics[knowledgeCenter.topics.Count-1];
        }
        [HttpPost("{id}")]
        public Post CreateNewPost([FromRoute] int id,[FromQuery] string name, [FromQuery] string post) //I know that I need use DTO! For test! I will make it better
        {
            KnowledgeCenter knowledgeCenter = KnowledgeCenter.getInstance();
            Topic topic = knowledgeCenter.topics[id];
            topic.Posts.Add(new Post(topic.GetNextId(),DateTime.UtcNow,post,name));
            return topic.Posts[topic.Posts.Count - 1];
        }
    }
}
