using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///  Błędy typowe dla serwisu LogService
    ///  Kody z prefixem "08"
    /// </summary>
    public class LogErrors
    {
        public static readonly string ErrorCodePrefix = "08";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        ///     Nie udało się skonwertować daty z nazwy pliku
        /// </summary>
        public DetailedError ConvertingDateFromFileNameFailed = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie udało się skonwertować daty z nazwy pliku"
        };

        /// <summary>
        ///     Błąd przetwarzania danych
        /// </summary>
        public DetailedError ProcessingError = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Błąd przetwarzania danych"
        };
    }
}
