using HTTP_APi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi
{
    public class KnowledgeCenter //TODO DI
    {
        private static KnowledgeCenter instance;
        public List<Topic> topics = new List<Topic>();
        private KnowledgeCenter()
        { }
        public static KnowledgeCenter getInstance()
        {
            if (instance == null)
            {
                instance = new KnowledgeCenter();
                instance.topics.Add(new Topic(0, new DateTime(), "Добро пожаловать на форум!", "Owner"));
            }
            return instance;
        }
        public int GetNextId()
        {
            int id = 0;
            for (int i = 0; i < topics.Count; i++)
            {
                if (topics[i].id >= id)
                {
                    id = topics[i].id + 1;
                }
            }
            return id;
        }
    }
}
