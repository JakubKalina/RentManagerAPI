using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Tenancy : IHasIntId
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }


        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
