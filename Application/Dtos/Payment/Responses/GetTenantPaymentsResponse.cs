using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Payment.Responses
{
    public class GetTenantPaymentsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public string RecipientAccountNumber { get; set; }

        public virtual FlatForGetTenantPaymentsResponse Flat { get; set; }

        public virtual UserForGetTenantPaymentsResponse User { get; set; }
    }

    public class FlatForGetTenantPaymentsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class UserForGetTenantPaymentsResponse
    {
        public string Id { get; set; }
        public string SearchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
