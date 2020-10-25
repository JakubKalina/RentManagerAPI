using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Document : IHasIntId
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }

        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
