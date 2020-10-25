using System.Collections.Generic;

namespace Validation.Utilities
{
    internal static class Role
    {
        public static List<string> List = new List<string>
        {
            Administrator,
            Landlord,
            Tenant
        };
#warning W przypadku dodania nowej roli należy tą zmianę odzwierciedlić w klasie Domain.Models.Role
        public const string Administrator = "Administrator";
        public const string Landlord = "Landlord";
        public const string Tenant = "Tenant";
    }
}
