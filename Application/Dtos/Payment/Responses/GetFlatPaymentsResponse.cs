using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Payment.Responses
{
    public class GetFlatPaymentsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public string RecipientAccountNumber { get; set; }

        public virtual UserForGetFlatPaymentsResponse User { get; set; }
    }

    public class UserForGetFlatPaymentsResponse
    {
        public string Id { get; set; }
        public string SearchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
