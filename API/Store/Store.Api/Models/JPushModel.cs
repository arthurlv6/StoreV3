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

    public class Intent
    {
        public string url { get; set; }
    }

    public class Extras
    {
        public int newsid { get; set; }
    }

    public class Android
    {
        public string alert { get; set; }
        public string title { get; set; }
        public int builder_id { get; set; }
        public string large_icon { get; set; }
        public Intent intent { get; set; }
        public Extras extras { get; set; }
    }

    public class Extras2
    {
        public int newsid { get; set; }
    }

    public class Ios
    {
        public string alert { get; set; }
        public string sound { get; set; }
        public string badge { get; set; }
        [JsonProperty("thread-id")]
        public string ThreadId { get; set; }
        public Extras2 extras { get; set; }
    }

    public class Voip
    {
        public string key { get; set; }
    }

    public class Notification
    {
        public Android android { get; set; }
        public Ios ios { get; set; }
        public Voip voip { get; set; }
    }

    public class Extras3
    {
        public string key { get; set; }
    }

    public class Message
    {
        public string msg_content { get; set; }
        public string content_type { get; set; }
        public string title { get; set; }
        public Extras3 extras { get; set; }
    }

    public class TempPara
    {
        public string code { get; set; }
    }

    public class SmsMessage
    {
        public int temp_id { get; set; }
        public TempPara temp_para { get; set; }
        public int delay_time { get; set; }
        public bool active_filter { get; set; }
    }

    public class Options
    {
        public int time_to_live { get; set; }
        public bool apns_production { get; set; }
        public string apns_collapse_id { get; set; }
    }

    public class Params
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public class Callback
    {
        public string url { get; set; }
        public Params @params { get; set; }
        public int type { get; set; }
    }

    public class JPushModel
    {
        public string cid { get; set; }
        public string platform { get; set; }
        public Audience audience { get; set; }
        public Notification notification { get; set; }
        public Message message { get; set; }
        public SmsMessage sms_message { get; set; }
        public Options options { get; set; }
        public Callback callback { get; set; }
    }
}
