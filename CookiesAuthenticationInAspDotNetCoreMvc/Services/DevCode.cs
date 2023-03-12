using System.Linq;
using System.Security.Claims;

namespace CookiesAuthenticationInAspDotNetCoreMvc.Services {
    public static class DevCode {
        public static string GetSpecificClaim(this ClaimsIdentity claimsIdentity, string claimType) {
            var claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == claimType);

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
