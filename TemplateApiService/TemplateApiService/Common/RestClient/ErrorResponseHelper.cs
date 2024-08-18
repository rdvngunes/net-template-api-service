using TemplateApiService.Common.Enums;
using TemplateApiService.Common.RedisDbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RestClient
{
    public class ErrorResponseHelper
    {
        private readonly LanguageTranslationHelper _languageTranslationHelper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="languageTranslationHelper"></param>
        public ErrorResponseHelper(LanguageTranslationHelper languageTranslationHelper)
        {
            _languageTranslationHelper = languageTranslationHelper;
        }

        /// <summary>
        /// Get Error Result
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="languageResourceName"></param>
        /// <param name="isGeneric"></param>
        /// <returns></returns>
        public async Task<ApiRestResponseResult> GetErrorResult(int httpStatusCode, string languageResourceName = "", bool isGeneric = true)
        {
            ApiRestResponseResult result = new ApiRestResponseResult();
            result.Status = EnumHttpStatusCode.error;

            switch (httpStatusCode)
            {
                case (int)HttpStatusCode.NoContent:
                    // Get Language Transalation
                    string userNotFoundMessage = await _languageTranslationHelper.GetTranslation(EnumGenericLanguageResources.no_user_found.ToString(), isGeneric);
                    result.IsSuccessStatusCode = false;
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                    result.Error = new ErrorViewModel(new List<string> { userNotFoundMessage });
                    break;
                case (int)HttpStatusCode.NotFound:
                    // Get Language Transalation
                    string notFoundMessage = await _languageTranslationHelper.GetTranslation(EnumGenericLanguageResources.no_data_found.ToString(), isGeneric);
                    result.IsSuccessStatusCode = false;
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                    result.Error = new ErrorViewModel(new List<string> { notFoundMessage });
                    break;
                case (int)HttpStatusCode.BadRequest:
                    // Get Language Transalation
                    string badRequestMessage = await _languageTranslationHelper.GetTranslation(languageResourceName, isGeneric);
                    result.IsSuccessStatusCode = false;
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.Error = new ErrorViewModel(new List<string> { badRequestMessage });
                    break;
                default:
                    // Get Language Transalation
                    string internalServerErrorMessage = await _languageTranslationHelper.GetTranslation(EnumGenericLanguageResources.internal_error.ToString(), isGeneric);
                    result.IsSuccessStatusCode = false;
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.Error = new ErrorViewModel(new List<string> { internalServerErrorMessage });
                    break;
            }

            return result;
        }
    }
}
