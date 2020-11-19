using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Report.Requests
{
    public class CreateTenantReportRequest
    {
        public int FlatId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
