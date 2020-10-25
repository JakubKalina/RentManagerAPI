using Application.Dtos.Message.Requests;
using Application.Dtos.Message.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        /// <summary>
        /// Metoda zwracająca ostatnie wiadomości w konwersacji pomiędzy zalogowanym i wybranym użytkownikiem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetConversationMessagesResponse>> GetConversationMessagesAsync(GetConversationMessagesRequest request);

        /// <summary>
        /// Metoda wysyłająca wiadomość od zalogowanego użytkownika do wybranego
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> SendMessageAsync(SendMessageRequest request);

        /// <summary>
        /// Metoda zwracająca wszystkie ostatnie konwersacje użytkownika
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetConversationsResponse>> GetConversationsAsync(GetConversationsRequest request);
  
    }
}
