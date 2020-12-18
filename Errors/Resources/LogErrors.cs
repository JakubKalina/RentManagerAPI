using Validation.Models;

namespace Validation.Resources
{

    public class LogErrors
    {
        public static readonly string ErrorCodePrefix = "08";
        public static int ErrorCodeSuffix = 1;


        public DetailedError ConvertingDateFromFileNameFailed = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie udało się skonwertować daty z nazwy pliku"
        };


        public DetailedError ProcessingError = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Błąd przetwarzania danych"
        };
    }
}
