using TemplateApiService.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RedisDbClient
{
    public class LanguageTranslationHelper
    {
        private readonly RedisDbClientHelper _redisDbClientHelper;
        private readonly AuthorizationClaimsProvider _authorizationClaimsProvider;

        public LanguageTranslationHelper(RedisDbClientHelper redisDbClientHelper, AuthorizationClaimsProvider authorizationClaimsProvider)
        {
            _redisDbClientHelper = redisDbClientHelper;
            _authorizationClaimsProvider = authorizationClaimsProvider;
        }

        public async Task<string> GetTranslation(string resourceName, bool isGeneric = false)
        {
            // Get Language Transalation
            string translatedMessage = await _redisDbClientHelper.GetLanguageResourceValue(resourceName, _authorizationClaimsProvider.Language, isGeneric);

            return translatedMessage;
        }

        public async Task<string> GetTranslationForDynamicContent(string message)
        {
            // Get Language Transalation
            string translatedMessage = await _redisDbClientHelper.GetTranslationForDynamicContent(message, _authorizationClaimsProvider.Language);

            return translatedMessage;
        }
    }
}
