using Validation.Models;
using Validation.Utilities;

namespace Validation.Resources
{
    /// <summary>
    ///     Błędy typowe dla serwisu EmailService
    ///     Kody z prefixem "06"
    /// </summary>
    public class EmailErrors
    {
        public static readonly string ErrorCodePrefix = "06";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        /// Wystąpił błąd podczas wysyłania emaila pod adres {0} z linkiem potwierdzającym
        /// </summary>
        public DetailedError ErrorOccuredWhileSendingEmailWithConfirmationLink = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas wysyłania emaila pod adres {0} z linkiem potwierdzającym"
        };
    }
}