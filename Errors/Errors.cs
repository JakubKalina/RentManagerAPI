using Validation.Resources;

namespace Validation
{
    public static class Errors
    {
        public static AccountErrors AccountErrors { get; set; }

        public static MaintenanceErrors MaintenanceErrors { get; set; }

        public static DatabaseErrors DatabaseErrors { get; set; }

        public static UserCreatorErrors UserCreatorErrors { get; set; }

        public static AuthErrors AuthErrors { get; set; }

        public static EmailErrors EmailErrors { get; set; }

        public static FileErrors FileErrors { get; set; }

        public static LogErrors LogErrors { get; set; }

        static Errors()
        {
            AccountErrors = new AccountErrors();
            MaintenanceErrors = new MaintenanceErrors();
            DatabaseErrors = new DatabaseErrors();
            UserCreatorErrors = new UserCreatorErrors();
            AuthErrors = new AuthErrors();
            EmailErrors = new EmailErrors();
            LogErrors = new LogErrors();
        }
    }
}