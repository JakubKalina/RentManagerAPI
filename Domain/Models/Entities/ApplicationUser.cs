using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Interfaces;

namespace Domain.Models.Entities
{
    public class ApplicationUser : IdentityUser, IHasStringId
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
    }
}