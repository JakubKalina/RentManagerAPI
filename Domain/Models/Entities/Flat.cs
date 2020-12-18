using Domain.Models.Entities.Association;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Flat : IHasIntId
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<FlatInformation> FlatInformations { get; set; }

        public virtual ICollection<Tenancy> Tenancies { get; set; }

        public virtual ICollection<FlatLandlord> FlatLandlords { get; set; }

    }
}
