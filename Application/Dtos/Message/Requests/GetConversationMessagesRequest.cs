using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos.Message.Requests
{
    public class GetConversationMessagesRequest : PaginationQuery
    {
        /// <summary>
        /// Id użytkownika z którym zalogowana osoba przeglada konwersacje
        /// </summary>
        [Required]
        public string RecipientId { get; set; }
    }
}
