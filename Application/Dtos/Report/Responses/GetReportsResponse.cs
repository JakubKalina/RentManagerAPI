using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Report.Responses
{
    public class GetReportsResponse : PagedResponse<ReportForGetReportsResponse>
    {
        public GetReportsResponse(PaginationQuery request, IEnumerable<ReportForGetReportsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class ReportForGetReportsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; }

        public int FlatId { get; set; }

        public string SenderId { get; set; }

    }
}
