using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP_APi.Models
{
    public class NewPostDTO
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public NewPostDTO(string Message, string Name)
        {
            this.Message = Message;
            this.Name = Name;
        }
    }
}
