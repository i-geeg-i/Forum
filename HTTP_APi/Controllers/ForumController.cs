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
        public List<Forum> forums = new List<Forum>();

        private readonly ILogger<WeatherForecastController> _logger;

        public ForumController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            forums.Add(new Forum(0, new DateTime(), "Добро пожаловать на форум!", "Owner"));
        }

        [HttpGet]
        public Forum Get()
        {
            return forums[0];
        }
        [HttpGet("{id}")]
        public Forum GetPost([FromRoute] int id)
        {
            for (int i = 0; i < forums.Count; i++)
            {
                if (forums[i].id == id)
                {
                    return forums[i];
                }

            }
            HttpContext.Response.StatusCode = 404;
            return new Forum(-1, new DateTime(), "Неверный номер темы!", "Creator");
        }
        private int CreateId()
        {
            int forReturn = 1;
            for(int i = 0; i < forums.Count; i++)
            {
                if (forums[i].id >= forReturn)
                {
                    forReturn = forums[i].id + 1;
                }
            }
            return forReturn;
        }
        [HttpGet("new")]
        public Forum CreateNew([FromQuery] string name, [FromQuery] string post)
        {
            forums.Add(new Forum(CreateId(), DateTime.UtcNow, post, name));
            return forums[forums.Count-1];
        }
    }
}
