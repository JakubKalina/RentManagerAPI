using Validation.Models;

namespace Validation.Resources
{

    public class MaintenanceErrors
    {
        public static readonly string ErrorCodePrefix = "02";
        public static int ErrorCodeSuffix = 1;


        public DetailedError StartDateMustBeNotGreaterThanEndDate = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Data rozpoczęcia nie może być większa, niż data zakończenia"
        };
    }
}