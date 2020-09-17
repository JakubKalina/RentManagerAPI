using System;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Interfaces;

namespace Domain.Models.Entities
{
    public class MaintenanceMessage : IHasIntId
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required, MaxLength(512)]
        public string Description { get; set; }
    }
}