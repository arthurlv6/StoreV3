using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class Audience
    {
        public List<string> tag { get; set; }
    }

    public class Message
    {
        public string msg_content { get; set; }
        public string content_type { get; set; } = "text";
        public string title { get; set; } = "msg";
    }


    public class JPushModel
    {
        public string platform { get; set; }
        public Audience audience { get; set; }
        public Message message { get; set; }
    }
}
