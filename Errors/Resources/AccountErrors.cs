using Validation.Models;

namespace Validation.Resources
{
    /// <summary>
    ///     Błędy typowe dla serwisu AccountService
    ///     Kody z prefixem "01"
    /// </summary>
    public class AccountErrors
    {
        public static readonly string ErrorCodePrefix = "01";
        public static int ErrorCodeSuffix = 1;

        /// <summary>
        ///     Nie znaleziono użytkownika
        /// </summary>
        public DetailedError UserNotFound = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie znaleziono użytkownika"
        };

        /// <summary>
        ///     Nie znaleziono użytkownika o podanym emailu \"{0}\"
        /// </summary>
        public DetailedError CouldNotFindUserWithGivenEmail = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie znaleziono użytkownika o podanym emailu \"{0}\""
        };

        /// <summary>
        ///     Wystąpił błąd podczas aktualizowania konta użytkownika
        /// </summary>
        public DetailedError ErrorOccuredWhileUpdatingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas aktualizowania konta użytkownika"
        };

        /// <summary>
        ///     Wystąpił błąd podczas potwierdzania emaila
        /// </summary>
        public DetailedError ErrorOccuredWhileConfirmingEmail = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas potwierdzania emaila"
        };

        /// <summary>
        ///     Wystąpił błąd podczas zmiany hasła
        /// </summary>
        public DetailedError ErrorOccuredWhileChangingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas zmiany hasła"
        };

        /// <summary>
        ///     Wystąpił błąd podczas resetowania hasła
        /// </summary>
        public DetailedError ErrorOccuredWhileResettingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas resetowania hasła"
        };

        /// <summary>
        ///     Wystąpił błąd podczas tworzenia użytkownika
        /// </summary>
        public DetailedError ErrorOccuredWhileCreatingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas tworzenia użytkownika"
        };

        /// <summary>
        ///     Wystąpił błąd podczas usuwania użytkownika
        /// </summary>
        public DetailedError ErrorOccuredWhileDeletingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas usuwania użytkownika"
        };

        /// <summary>
        ///     Wystąpił błąd podczas ustawiania hasła użytkownika
        /// </summary>
        public DetailedError ErrorOccuredWhileSettingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas ustawiania hasła użytkownika"
        };

        /// <summary>
        ///     Usunięte konto nie może zostać potwierdzone
        /// </summary>
        public DetailedError DeletedAccountCanNotBeConfirmed = new DetailedError
        {
            ErrorCode = "01-07",
            DescriptionFormatter = "Usunięte konto nie może zostać potwierdzone"
        };

        /// <summary>
        /// Konto z adresem email {0} jest już potwierdzone
        /// </summary>
        public DetailedError EmailIsAlreadyConfirmed = new DetailedError
        {
            ErrorCode = "01-08",
            DescriptionFormatter = "Konto z adresem email {0} jest już potwierdzone"
        };
    }
}