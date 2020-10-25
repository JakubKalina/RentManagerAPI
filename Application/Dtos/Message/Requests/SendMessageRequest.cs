using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Message.Requests
{
    public class SendMessageRequest
    {
        public string ReceiverId { get; set; }
        public string Message { get; set; }
    }
}
