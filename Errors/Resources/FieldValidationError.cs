using Validation.Models;

namespace Validation.Resources
{

    public static class FieldValidationError
    {
        public static readonly string ErrorCodePrefix = "00";
        public static int ErrorCodeSuffix = 1;

        public static readonly DetailedErrorWithTemplate FieldLengthMustNotBeGreaterThan = new DetailedErrorWithTemplate
        {
            Template = "The field {0} must be a string or array type with a maximum length of '{1}'.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Długość pola {0} nie może być większa, niż {1}"
        };

        public static readonly DetailedErrorWithTemplate FieldLengthMustNotBeLessThan = new DetailedErrorWithTemplate
        {
            Template = "The field {0} must be a string or array type with a minimum length of '{1}'.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Długość pola {0} nie może być mniejsza, niż {1}"
        };

        public static readonly DetailedErrorWithTemplate FieldIsRequired = new DetailedErrorWithTemplate
        {
            Template = "The {0} field is required.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} jest wymagane"
        };

        public static readonly DetailedErrorWithTemplate FieldValueMustBeBetween = new DetailedErrorWithTemplate
        {
            Template = "The field {0} must be between {1} and {2}.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wartość pola {0} musi być z przedziału [{1}, {2}]"
        };

        public static readonly DetailedErrorWithTemplate FieldAndOtherFieldAreNotEqual = new DetailedErrorWithTemplate
        {
            Template = "'{0}' and '{1}' do not match.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pola {0} oraz {1} nie są sobie równe"
        };

        public static readonly DetailedErrorWithTemplate PasswordMustContainAtLeastOneLowercaseLetter = new DetailedErrorWithTemplate
        {
            Template = "The {0} must contain at least one lowercase letter.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} musi zawierać małą literę"
        };

        public static readonly DetailedErrorWithTemplate PasswordMustContainUppercaseLetter = new DetailedErrorWithTemplate
        {
            Template = "The {0} must contain at least one uppercase letter.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} musi zawierać wielką literę"
        };

        public static readonly DetailedErrorWithTemplate PasswordMustContainNumber = new DetailedErrorWithTemplate
        {
            Template = "The {0} must contain at least one number.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} musi zawierać cyfrę"
        };

        public static readonly DetailedErrorWithTemplate PasswordMustContainSpecialCharacter = new DetailedErrorWithTemplate
        {
            Template = "The {0} must contain at least one special character.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} musi zawierać znak specjalny np. #$^+=!*()@%&"
        };

        public static readonly DetailedErrorWithTemplate PasswordMustContainAtLeastXCharacters = new DetailedErrorWithTemplate
        {
            Template = "The {0} must be at least {0} characters long.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} musi mieć co najmniej {1} znaków"
        };

        public static readonly DetailedErrorWithTemplate FieldContainsRoleThatDoesNotExist = new DetailedErrorWithTemplate
        {
            Template = "The {0} field contains invalid role names.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} zawiera niepoprawną nazwę roli"
        };

        public static readonly DetailedErrorWithTemplate InvalidUrl = new DetailedErrorWithTemplate
        {
            Template = "The {0} field is not a valid fully-qualified http, https, or ftp URL.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} jest niepoprawnym adresem URL"
        };

        public static readonly DetailedErrorWithTemplate InvalidEmail = new DetailedErrorWithTemplate
        {
            Template = "The {0} field is not a valid e-mail address.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} jest niepoprawnym adresem email"
        };

        public static readonly DetailedErrorWithTemplate InvalidPhoneNumber = new DetailedErrorWithTemplate
        {
            Template = "The {0} field is not a valid phone number.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Pole {0} jest niepoprawnym numerem telefonu"
        };

        public static readonly DetailedErrorWithTemplate InvalidValueForField = new DetailedErrorWithTemplate
        {
            Template = "The value {0} is not valid for {1}.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wartość {0} dla pola {1} jest niepoprawna"
        };

        public static readonly DetailedErrorWithTemplate NotValidValue = new DetailedErrorWithTemplate
        {
            Template = "The value {0} is not valid.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wartość {0} jest niepoprawna"
        };

        public static readonly DetailedErrorWithTemplate InvalidValue = new DetailedErrorWithTemplate
        {
            Template = "The value {0} is invalid.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wartość {0} jest niepoprawna"
        };

        public static readonly DetailedErrorWithTemplate UnknownError = new DetailedErrorWithTemplate
        {
            Template = "Unknown error occured.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Wystąpił błąd"
        };

        public static readonly DetailedErrorWithTemplate FileIsTooBig = new DetailedErrorWithTemplate
        {
            Template = "File {0} larger than {1} MB.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Plik {0} jest większy niż {1} MB."
        };

        public static readonly DetailedErrorWithTemplate NotAllowedFileExtension = new DetailedErrorWithTemplate
        {
            Template = "Only {0} extensions allowed.",
            ErrorCode = $"{ErrorCodePrefix}-{ErrorCodeSuffix++}",
            DescriptionFormatter = "Tylko {0} rozszerzenia są dozwolone."
        };
    }
}