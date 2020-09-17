using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///  Błędy typowe dla plików
    ///  Kody z prefixem "07"
    /// </summary>
    public class FileErrors
    {
        public static readonly string ErrorCodePrefix = "07";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        /// "\"{0}\" - Nieobsługiwany typ pliku. Dozwolone rozszerzenie to \"{1}\""
        /// </summary>
        public DetailedError NotSupportedFileType = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "\"{0}\" - Nieobsługiwany typ pliku. Dozwolone rozszerzenie to \"{1}\""
        };
    }
}
