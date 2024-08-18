using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Security
{
    public class AuthorizationClaimsProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Token { get { return _httpContextAccessor.HttpContext.Request.Headers["Authorization"]; } }

        public string Language
        {
            get
            {
                return !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["x-language"]) ?
                    _httpContextAccessor.HttpContext.Request.Headers["x-language"].ToString() : "en";
            }
        }

        public AuthorizationClaimsProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserId()
        {

            return _httpContextAccessor.HttpContext.User.Claims.
                Where(x => x.Type == ClaimTypes.NameIdentifier).
                Select(x => x.Value).FirstOrDefault();
        }
    }
}
