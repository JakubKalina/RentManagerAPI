using System.Collections.Generic;

namespace Domain.Models
{

    public static class Role
    {
        public static List<string> List = new List<string>
        {
            Administrator,
            Landlord,
            Tenant
        };
        public const string Administrator = "Administrator";
        public const string Landlord = "Landlord";
        public const string Tenant = "Tenant";
    }
}