using Newtonsoft.Json;
using System;


namespace TemplateApiService.ViewModels.OAuth
{
    public class OAuthTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("refresh_expires_in")]
        public long RefreshExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("not-before-policy")]
        public long NotBeforePolicy { get; set; }

        [JsonProperty("session_state")]
        public Guid SessionState { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Returns the Token with the Bearer type
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizationToken()
        {
            return string.Format("{0} {1}", TokenType, AccessToken);
        }
    }
}
