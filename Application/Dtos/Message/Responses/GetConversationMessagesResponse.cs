using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Message.Responses
{
    public class GetConversationMessagesResponse : PagedResponse<MessageForGetConversationMessagesResponse>
    {
        public GetConversationMessagesResponse(PaginationQuery request, IEnumerable<MessageForGetConversationMessagesResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {
                
        }
    }

    public class MessageForGetConversationMessagesResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserFromId { get; set; }
        public string UserToId { get; set; }
    }
}
