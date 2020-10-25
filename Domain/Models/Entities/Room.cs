using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Room : IHasIntId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<Tenancy> Tenancies { get; set; }

    }
}
