using Validation.Models;

namespace Validation.Resources
{

    public class AccountErrors
    {
        public static readonly string ErrorCodePrefix = "01";
        public static int ErrorCodeSuffix = 1;


        public DetailedError UserNotFound = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie znaleziono użytkownika"
        };


        public DetailedError CouldNotFindUserWithGivenEmail = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Nie znaleziono użytkownika o podanym emailu \"{0}\""
        };

        public DetailedError ErrorOccuredWhileUpdatingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas aktualizowania konta użytkownika"
        };

        public DetailedError ErrorOccuredWhileConfirmingEmail = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas potwierdzania emaila"
        };

        public DetailedError ErrorOccuredWhileChangingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas zmiany hasła"
        };

        public DetailedError ErrorOccuredWhileResettingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas resetowania hasła"
        };

        public DetailedError ErrorOccuredWhileCreatingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas tworzenia użytkownika"
        };

        public DetailedError ErrorOccuredWhileDeletingUser = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas usuwania użytkownika"
        };

        public DetailedError ErrorOccuredWhileSettingPassword = new DetailedError
        {
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd podczas ustawiania hasła użytkownika"
        };

        public DetailedError DeletedAccountCanNotBeConfirmed = new DetailedError
        {
            ErrorCode = "01-07",
            DescriptionFormatter = "Usunięte konto nie może zostać potwierdzone"
        };

        public DetailedError EmailIsAlreadyConfirmed = new DetailedError
        {
            ErrorCode = "01-08",
            DescriptionFormatter = "Konto z adresem email {0} jest już potwierdzone"
        };
    }
}