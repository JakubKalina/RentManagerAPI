using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Message.Responses
{
    public class GetConversationsResponse : PagedResponse<ConversationForGetConversationsResponse>
    {
        public GetConversationsResponse(PaginationQuery request, IEnumerable<ConversationForGetConversationsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class ConversationForGetConversationsResponse
    {
        public UserForConversationForGetConversationsResponse User { get; set; }

        public MessageForConversationForGetConversationsResponse Message { get; set; }
    }

    public class UserForConversationForGetConversationsResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MessageForConversationForGetConversationsResponse
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
