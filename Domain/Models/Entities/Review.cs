using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Review : IHasIntId
    {
        public int Id { get; set; }

        public int Rate { get; set; }

        public string Description { get; set; }

        public string UserFromId { get; set; }
        public virtual ApplicationUser UserFrom { get; set; }

        public string UserToId { get; set; }

        public virtual ApplicationUser UserTo { get; set; }
    }
}
