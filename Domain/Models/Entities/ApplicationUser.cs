using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Interfaces;
using System.Collections.Generic;
using Domain.Models.Entities.Association;

namespace Domain.Models.Entities
{
    public class ApplicationUser : IdentityUser, IHasStringId
    {
        /// <summary>
        /// Dodatkowe Id użytkownika pozwalające na jego wyszukanie - przykładowo #4892
        /// </summary>
        [MaxLength(4)]
        public string SearchId { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Review> ReceivedReviews { get; set; }
        public virtual ICollection<Review> SentReviews { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Tenancy> Tenancies { get; set; }
        public virtual ICollection<FlatLandlord> FlatLandlords { get; set; }

    }
}