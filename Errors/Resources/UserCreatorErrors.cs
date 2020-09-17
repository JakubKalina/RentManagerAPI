using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///     Błędy typowe dla UserCreator
    ///     Kody z prefixem "05"
    /// </summary>
    public class UserCreatorErrors
    {
        public static readonly string ErrorCodePrefix = "05";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        /// Rola \"{0}\" nie istnieje
        /// </summary>
        public DetailedError GivenRoleDoesNotExist = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Rola \"{0}\" nie istnieje"
        };

        /// <summary>
        ///     Adres email \"{0}\" jest już zajęty
        /// </summary>
        public DetailedError EmailIsAlreadyTaken = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Adres email \"{0}\" jest już zajęty"
        };
    }
}