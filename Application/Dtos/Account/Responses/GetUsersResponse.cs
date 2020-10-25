using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Account.Responses
{
    public class GetUsersResponse : PagedResponse<UserForGetUsersResponse>
    {
        public GetUsersResponse(PaginationQuery request, IEnumerable<UserForGetUsersResponse> data,int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {
         
        }
    }

    public class UserForGetUsersResponse
    {
        public string Id { get; set; }
        public string SearchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
