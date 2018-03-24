namespace SpaTemplates.Web.Server.Models
{
    public static class JwtConstants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Role = "role", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
