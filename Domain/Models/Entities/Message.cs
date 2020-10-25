using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Message : IHasIntId
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public string UserFromId { get; set; }
        public virtual ApplicationUser UserFrom { get; set; }

        public string UserToId { get; set; }
        public virtual ApplicationUser UserTo { get; set; }
    }
}
