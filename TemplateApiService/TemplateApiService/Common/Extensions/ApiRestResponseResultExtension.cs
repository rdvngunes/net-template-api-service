using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemplateApiService.Common.Enums;
using TemplateApiService.Common.RestClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using HttpResponse = Jal.HttpClient.Model.HttpResponse;

namespace TemplateApiService.Common.Extensions
{
    /// <summary>
    /// ApiRestResponse Extension Class
    /// </summary>
    public static class ApiRestResponseExtension
    {
        /// <summary>
        /// ApiRestResponse Extension Method 
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public static ApiRestResponseResult ToApiRestResponseResult(this HttpResponseMessage httpResponseMessage)
        {
            try
            {
                ApiRestResponseResult restResponse = new ApiRestResponseResult();
                restResponse.StatusCode = (int)httpResponseMessage.StatusCode;
                restResponse.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
                restResponse.Content = httpResponseMessage.Content.ReadAsStringAsync().Result;

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    restResponse.Status = EnumHttpStatusCode.fail;
                    restResponse.Error = new ErrorViewModel(new List<string> { $"Error - {restResponse.Content}. Status code - {(int)httpResponseMessage.StatusCode}" });
                }

                return restResponse;
            }
            catch (Exception ex)
            {
                ApiRestResponseResult result = new ApiRestResponseResult();
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.IsSuccessStatusCode = false;
                result.Status = EnumHttpStatusCode.error;
                result.Error = new ErrorViewModel(new List<string> { ex.Message });
                return result;
            }
        }

        /// <summary>
        /// ApiRestResponse Extension Method 
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public static ApiRestResponseResult ToApiRestResponseResult(this HttpResponse httpResponseMessage)
        {
            try
            {
                ApiRestResponseResult restResponse = new ApiRestResponseResult();
                restResponse.StatusCode = (int)httpResponseMessage.HttpStatusCode;
                restResponse.IsSuccessStatusCode = httpResponseMessage.HttpExceptionStatus.HasValue ? false : true;
                restResponse.Content = httpResponseMessage.Content.Read();

                if (httpResponseMessage.HttpExceptionStatus.HasValue)
                {
                    restResponse.Status = EnumHttpStatusCode.fail;
                    restResponse.Error = new ErrorViewModel(new List<string> { $"Error - {restResponse.Content}. Status code - {restResponse.StatusCode}" });
                }

                return restResponse;
            }
            catch (Exception ex)
            {
                ApiRestResponseResult result = new ApiRestResponseResult();
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.IsSuccessStatusCode = false;
                result.Status = EnumHttpStatusCode.error;
                result.Error = new ErrorViewModel(new List<string> { ex.Message });
                return result;
            }
        }


        /// <summary>
        /// ApiRestResponse Extension Method
        /// </summary>
        /// <param name="apiRestResponseResult"></param>
        /// <returns></returns>
        public static ObjectResult ToObjectResult(this ApiRestResponseResult apiRestResponseResult)
        {
            ObjectResult result = new ObjectResult(apiRestResponseResult);
            result.StatusCode = apiRestResponseResult.StatusCode;

            return result;
        }

    }
}
