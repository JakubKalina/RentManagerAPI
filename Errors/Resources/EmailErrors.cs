using Validation.Models;
using Validation.Utilities;

namespace Validation.Resources
{
    public class EmailErrors
    {
        public static readonly string ErrorCodePrefix = "06";
        public static int ErrorCodeSuffix = 1;

        public DetailedError ErrorOccuredWhileSendingEmailWithConfirmationLink = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas wysyłania emaila pod adres {0} z linkiem potwierdzającym"
        };
    }
}