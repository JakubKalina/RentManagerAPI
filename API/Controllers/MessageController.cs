using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Message.Requests;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Zwraca konwersacje zalogowanego użytkownika
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetConversationsRequest))]
        [HttpGet("conversations")]
        public async Task<IActionResult> GetConversations([FromQuery] GetConversationsRequest request)
        {
            var response = await _messageService.GetConversationsAsync(request);
            return SendResponse(response);
        }

        /// <summary>
        /// Zwraca wybraną ilość wiadomości z konwersacji
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetConversationMessagesRequest))]
        [HttpGet("conversation")]
        public async Task<IActionResult> GetConversationMessages([FromQuery] GetConversationMessagesRequest request)
        {
            var response = await _messageService.GetConversationMessagesAsync(request);
            return SendResponse(response);
        }

        /// <summary>
        /// Zwraca wybraną ilość wiadomości z konwersacji
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromBody] SendMessageRequest request)
        {
            var response = await _messageService.SendMessageAsync(request);
            return SendResponse(response);
        }

    }
}
