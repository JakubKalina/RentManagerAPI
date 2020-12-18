using Validation.Models;

namespace Validation.Resources
{

    public class AuthErrors
    {
        public static readonly string ErrorCodePrefix = "06";
        public static int ErrorCodeSuffix = 1;

        public DetailedError YourAccountWasDeleted = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Twoje konto zostało usunięte"
        };


        public DetailedError AnErrorOccuredWhileAuthenticating = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd uwierzytelniania"
        };
    }
}