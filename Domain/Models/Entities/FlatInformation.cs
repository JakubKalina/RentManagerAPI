using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class FlatInformation : IHasIntId
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public int FlatId { get; set; }

        public virtual Flat Flat { get; set; }
    }
}
