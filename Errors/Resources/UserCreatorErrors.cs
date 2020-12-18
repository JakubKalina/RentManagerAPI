using Validation.Models;

namespace Validation.Resources
{

    public class UserCreatorErrors
    {
        public static readonly string ErrorCodePrefix = "05";
        public static int ErrorCodeSuffix = 1;

        public DetailedError GivenRoleDoesNotExist = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Rola \"{0}\" nie istnieje"
        };

        public DetailedError EmailIsAlreadyTaken = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Adres email \"{0}\" jest już zajęty"
        };
    }
}