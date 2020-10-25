using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Report.Requests
{
    public class GetReportsRequest : PaginationQuery
    {
        public int FlatId { get; set; }
        public bool IsArchived { get; set; }
    }
}
