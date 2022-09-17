using System;

namespace Chat.Server.Models
{
    public class Message
    {
        public string Text { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime Timestamp => DateTime.Now;
    }
}
