using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Payment : IHasIntId
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string RepeatEvery { get; set; }

        public string RecipientAccountNumber { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
