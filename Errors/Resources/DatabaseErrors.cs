using Validation.Models;

namespace Validation.Resources
{

    public class DatabaseErrors
    {
        public static readonly string ErrorCodePrefix = "03";
        public static int ErrorCodeSuffix = 1;


        public DetailedError ErrorOccuredWhileSaving = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas zapisu do bazy"
        };

        public DetailedError InvalidResourceIdentifier = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nieprawidłowy identyfikator zasobu"
        };
    }
}