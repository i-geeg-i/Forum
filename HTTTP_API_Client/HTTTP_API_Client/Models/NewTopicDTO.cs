using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi.Models
{
    public class NewTopicDTO
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public NewTopicDTO(string Title, string Name)
        {
            this.Title = Title;
            this.Name = Name;
        }
    }
}
