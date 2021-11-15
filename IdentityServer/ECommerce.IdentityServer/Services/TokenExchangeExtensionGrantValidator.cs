using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace ECommerce.IdentityServer.Services
{
    public class TokenExchangeExtensionGrantValidator : IExtensionGrantValidator
    {
        public string GrantType => "urn:ietf:params:oauth:grant-type:token-exchange";
        private readonly ITokenValidator _tokenValidator;

        public TokenExchangeExtensionGrantValidator(ITokenValidator tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var requestRaw = context.Request.Raw.ToString();

            var token = context.Request.Raw.Get("subject_token");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "token is missing");
                return;
            }

            var tokenValidationResult = await _tokenValidator.ValidateAccessTokenAsync(token);

            if (tokenValidationResult.IsError)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid token");

                return;
            }

            var subjectClaim = tokenValidationResult.Claims.FirstOrDefault(c => c.Type == "sub");

            if (subjectClaim is null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "token must contain sub value");

                return;
            }

            context.Result = new GrantValidationResult(subjectClaim.Value, "access_token", tokenValidationResult.Claims);
        }

    }
}
