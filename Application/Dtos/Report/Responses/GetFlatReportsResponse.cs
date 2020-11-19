using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Report.Responses
{
    public class GetFlatReportsResponse : PagedResponse<ReportForGetFlatReportsResponse>
    {
        public GetFlatReportsResponse(PaginationQuery request, IEnumerable<ReportForGetFlatReportsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class ReportForGetFlatReportsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Type { get; set; }

        public int FlatId { get; set; }

        public string SenderId { get; set; }

        public string SenderFirstName { get; set; }

        public string SenderLastName { get; set; }
    }
}
