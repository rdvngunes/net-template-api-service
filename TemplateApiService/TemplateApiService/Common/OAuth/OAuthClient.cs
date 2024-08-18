using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TemplateApiService.Common.Security;
using TemplateApiService.ViewModels.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;

namespace TemplateApiService.Common.OAuth
{
    public class OAuthAuthenticationClient
    {
        private DateTime? _expiration;
        private OAuthTokenResponse _tokenResponse;
        private string _message;

        private readonly TemplateConfiguration _configuration;
        private readonly ILogger<string> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Application Configuration Instance</param>
        /// <param name="logger">Logger Instance</param>
        public OAuthAuthenticationClient(TemplateConfiguration configuration, ILogger<string> logger)
        {
            _configuration = configuration;
            _logger = logger;

            //Get Access Token
            GetAuthenticationToken();
        }

        /// <summary>
        /// Method to get access token.
        /// </summary>

        private void GetAuthenticationToken()
        {
            try
            {
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}{1}", _configuration.OAuthServerUrl, $"/realms/{_configuration.OAuthRealm}/protocol/openid-connect/token"));

                //Setting the request body
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("grant_type", "password"));
                values.Add(new KeyValuePair<string, string>("username", _configuration.OAuthSSUserName));
                values.Add(new KeyValuePair<string, string>("password", _configuration.OAuthSSPassword));
                values.Add(new KeyValuePair<string, string>("client_id", _configuration.OAuthSSClientId));
                values.Add(new KeyValuePair<string, string>("client_secret", _configuration.OAuthSSClientSecret));
                values.Add(new KeyValuePair<string, string>("scope", string.Empty));

                request.Content = new FormUrlEncodedContent(values);

                var response = client.SendAsync(request).Result;

                _tokenResponse = JsonConvert.DeserializeObject<OAuthTokenResponse>(response.Content.ReadAsStringAsync().Result);

                _expiration = DateTime.UtcNow.AddSeconds(_tokenResponse.ExpiresIn);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                _logger.LogError("OAuthAuthenticationClient : {0}", ex);
            }
        }

        public string Token
        {
            get
            {
                if (!_expiration.HasValue || _expiration < DateTime.UtcNow.AddMinutes(2))
                {
                    GetAuthenticationToken();
                }

                return _tokenResponse != null ? _tokenResponse.GetAuthorizationToken() : _message;
            }
        }
    }
}
