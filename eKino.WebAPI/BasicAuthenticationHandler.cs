using eKino.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace eKino.WebAPI
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public IUserService UsersService { get; set; }
        public BasicAuthenticationHandler(IUserService usersService, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            UsersService = usersService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing auth header");
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');

            var username = credentials[0];
            var password = credentials[1];

            var user = UsersService.Login(username, password);

            if (user == null)
            {
                return AuthenticateResult.Fail("Incorrect username or password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}