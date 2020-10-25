using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Entities.Association
{
    public class FlatLandlord
    {
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 2)]
        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
