using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Report : IHasIntId
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Type { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

    }
}
