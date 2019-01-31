using System.Security.Claims;
using System.Security.Principal;
namespace App.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetPlayer(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PlayerId");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}