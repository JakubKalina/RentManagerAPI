using Application.Dtos.Message.Requests;
using Application.Dtos.Message.Responses;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MessageService : Service, IMessageService
    {
        public MessageService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse<GetConversationMessagesResponse>> GetConversationMessagesAsync(GetConversationMessagesRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            //var dbQuery = Context.Messages.Where(m => m.UserFromId == userId || m.UserFromId == request.RecipientId || m.UserToId == userId || m.UserToId == request.RecipientId);
            var dbQuery = Context.Messages.Where(m => (m.UserToId == userId && m.UserFromId == request.RecipientId) || (m.UserFromId == userId && m.UserToId == request.RecipientId));

            var totalNumberOfItems = await dbQuery.CountAsync();
            var messages = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var messagesDto = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageForGetConversationMessagesResponse>>(messages).ToList();

            var response = new GetConversationMessagesResponse(request, messagesDto, totalNumberOfItems);

            return new ServiceResponse<GetConversationMessagesResponse>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<GetConversationsResponse>> GetConversationsAsync(GetConversationsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var dbQuery = Context.Messages.Where(m => m.UserFromId == userId || m.UserToId == userId)
                .DistinctBy(m => new { m.UserFromId, m.UserToId })
                .Select(m => new { m.UserFromId, m.UserToId, m.Timestamp, m.Content })
                .ToList();

            IList<ConversationForGetConversationsResponse> data = new List<ConversationForGetConversationsResponse>();
            foreach (var message in dbQuery)
            {
                var messageDto = new MessageForConversationForGetConversationsResponse()
                {
                    Content = message.Content,
                    Timestamp = message.Timestamp
                };
                var userDto = new UserForConversationForGetConversationsResponse();

                if (message.UserFromId == userId)
                {
                    var user = await GetEntityByIdAsync<ApplicationUser>(message.UserToId);
                    userDto = Mapper.Map<ApplicationUser, UserForConversationForGetConversationsResponse>(user);
                }
                else
                {
                    var user = await GetEntityByIdAsync<ApplicationUser>(message.UserFromId);
                    userDto = Mapper.Map<ApplicationUser, UserForConversationForGetConversationsResponse>(user);
                }

                if (data.Any(user => user.User.Id == userDto.Id))
                    continue;

                ConversationForGetConversationsResponse conversation = new ConversationForGetConversationsResponse()
                {
                    Message = messageDto,
                    User = userDto
                };

                data.Add(conversation);
            }

            var response = new GetConversationsResponse(request, data, 0);

            return new ServiceResponse<GetConversationsResponse>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse> SendMessageAsync(SendMessageRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            // Nadawca wiadomości
            var sender = await GetEntityByIdAsync<ApplicationUser>(userId);

            // Odbiorca wiadomości
            var receiver = await GetEntityByIdAsync<ApplicationUser>(request.ReceiverId);

            var message = new Message()
            {
                Content = request.Message,
                UserFrom = sender,
                UserTo = receiver,
                Timestamp = DateTime.Now
            };

            Context.Messages.Add(message);

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas wysyłania wiadomości od {sender.FirstName} {sender.LastName} do {receiver.FirstName} {receiver.LastName}" });
            return new ServiceResponse(HttpStatusCode.OK);
        }




    }
}
