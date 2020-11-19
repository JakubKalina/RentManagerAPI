using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Report.Requests
{
    public class GetFlatReportsRequest : PaginationQuery
    {
        public int FlatId { get; set; }
    }
}
