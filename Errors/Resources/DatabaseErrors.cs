using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///     Błędy typowe dla operacji na bazie danych
    ///     Kody z prefixem "03"
    /// </summary>
    public class DatabaseErrors
    {
        public static readonly string ErrorCodePrefix = "03";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        ///     Błąd ogólny
        ///     Wystąpił błąd podczas zapisu do bazy
        /// </summary>
        public DetailedError ErrorOccuredWhileSaving = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas zapisu do bazy"
        };

        /// <summary>
        ///     Nieprawidłowy identyfikator zasobu
        /// </summary>
        public DetailedError InvalidResourceIdentifier = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nieprawidłowy identyfikator zasobu"
        };
    }
}