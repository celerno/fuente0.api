
using System;
using Microsoft.AspNetCore.Authorization;

namespace fuente0.Middleware
{
    /// <summary>
    /// This requirement checks if the scope claim issued by your Auth0 tenant is present.
    /// If the scope claim exists, the requirement checks if the scope claim contains the requested scope.
    /// Source: https://auth0.com/docs/quickstart/backend/aspnet-core-webapi#configure-the-middleware
    /// </summary>
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}
