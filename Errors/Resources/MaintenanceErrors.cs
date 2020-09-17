using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///     Błędy typowe dla serwisu MaintenanceService
    ///     Kody z prefixem "02"
    /// </summary>
    public class MaintenanceErrors
    {
        public static readonly string ErrorCodePrefix = "02";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        ///     Data rozpoczęcia nie może być większa, niż data zakończenia
        /// </summary>
        // todo: przenieść do validatora
        public DetailedError StartDateMustBeNotGreaterThanEndDate = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Data rozpoczęcia nie może być większa, niż data zakończenia"
        };
    }
}