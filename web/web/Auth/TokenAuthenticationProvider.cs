using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;
using web.Controller.Interface;
using web.Utils;

namespace web.Auth
{
    public class TokenAuthenticationProvider : AuthenticationStateProvider, IAuthorizeService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient http;
        public static readonly string tokenKey = "tokenkey";

        public TokenAuthenticationProvider(IJSRuntime jsRuntime, HttpClient http)
        {
            _jsRuntime = jsRuntime;
            this.http = http;
        }

        private AuthenticationState notAtuthenticate => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_jsRuntime is IJSInProcessRuntime)
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "tokenkey");

                if (string.IsNullOrEmpty(token))
                {
                    return notAtuthenticate;
                }

                return CreatedAtActionResult(token);
            }

            return notAtuthenticate;
        }

        public AuthenticationState CreatedAtActionResult(string token)
        {
            //coloca O TOKEN obtido no header da requisição
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);



            return new AuthenticationState(new ClaimsPrincipal(
                new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));

        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task Login(string token)
        {
            await _jsRuntime.SetInLocalStorage("tokenkey", token);
            var authState = CreatedAtActionResult(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            await _jsRuntime.RemoveItem("tokenkey");
            NotifyAuthenticationStateChanged(Task.FromResult(notAtuthenticate));
        }
    }

}

