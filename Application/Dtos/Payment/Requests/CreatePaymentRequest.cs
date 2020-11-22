using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Payment.Requests
{
    public class CreatePaymentRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public string RecipientAccountNumber { get; set; }

        public int FlatId { get; set; }

        public int? RoomId { get; set; }

        public string UserId { get; set; }
    }
}
