using Validation.Models;

namespace Validation.Resources
{

    public class FileErrors
    {
        public static readonly string ErrorCodePrefix = "07";
        public static int ErrorCodeSuffix = 1;

        public DetailedError NotSupportedFileType = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "\"{0}\" - Nieobsługiwany typ pliku. Dozwolone rozszerzenie to \"{1}\""
        };
    }
}
