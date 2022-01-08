using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AmbrosiaAlert.Client.Extra
{
    public class LocalStorageAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;

        public LocalStorageAuthStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItem("authtoken");
            var handler = new JwtSecurityTokenHandler();

            var jwt = string.IsNullOrEmpty(token) switch
            {
                true => null,
                _ => handler.ReadJwtToken(token)
            };

            // TODO: check expiration
            var identity = jwt switch
            {
                JwtSecurityToken s => new ClaimsIdentity(handler.ReadJwtToken(token).Claims, "My custom auth service"),
                _ => new ClaimsIdentity()
            };
            var state = new AuthenticationState(new ClaimsPrincipal(identity));
            return state;
        }
    }
}
