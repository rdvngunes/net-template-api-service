using Mapster;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TemplateApiService.Common.RestClient;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RedisDbClient
{
    public class RedisDbClientHelper
    {
        public IDatabase _redisDBInstance { get; set; }
        public IServer _server { get; set; }
        private readonly TemplateConfiguration _config;
        private readonly ILogger<RedisDbClientHelper> _logger;

        public RedisDbClientHelper(TemplateConfiguration config, ILogger<RedisDbClientHelper> logger)
        {
            _config = config;
            _logger = logger;

            try
            {
                var database = ConnectionMultiplexer.Connect($"{_config.RedisUrl}:{_config.RedisPort},allowAdmin=true");
                _redisDBInstance = database.GetDatabase();
                _server = database.GetServer($"{config.RedisUrl}:{config.RedisPort}");

                //Seed Data For Testing
                AddLanguageResource();

                _logger.LogInformation($"RedisDbClientHelper ::: RedisConnection :: Connection successful");
            }
            catch (Exception ex)
            {
                _logger.LogError($"RedisDbClientHelper ::: RedisConnection :: Exception : {ex.Message}");
            }
        }

        private void AddLanguageResource()
        {
            //if (!_redisDBInstance.KeyExists("constraint_created_en"))
            //{
            Dictionary<string, string> resources = new Dictionary<string, string>();

            //English Transalation
            resources.Add("constraint_created_en", "Constraint created successfully.");
            resources.Add("constraint_updated_en", "Constraint updated successfully.");
            resources.Add("constraint_deleted_en", "Constraint deleted successfully.");
            resources.Add("constraint_does_not_exist_en", "Constraint not found.");
            resources.Add("constraint_already_exist_en", "Constraint already exist.");

            resources.Add("generic_no_data_found_en", "No data found. Please try again.");
            resources.Add("generic_no_user_found_en", "User not found.");
            resources.Add("generic_internal_error_en", "Internal error. Please contact system administrator.");


            // Hindi Transalation
            resources.Add("constraint_created_hi", "बाधा सफलतापूर्वक बनाया गया।");
            resources.Add("constraint_updated_hi", "बाधा सफलतापूर्वक अपडेट किया गया।");
            resources.Add("constraint_deleted_hi", "बाधा सफलतापूर्वक हटा दिया गया।");
            resources.Add("constraint_does_not_exist_hi", "बाधा मौजूद नहीं है।");

            foreach (var resource in resources)
            {
                _redisDBInstance.StringSet(resource.Key, resource.Value);
            }
            //}
        }

        public async Task<string> GetLanguageResourceValue(string resourceName, string language, bool isGeneric = false)
        {
            string resourceValueInEnglish = string.Empty;

            try
            {
                string defaultEnglishResourceKey = string.Format("{0}_{1}_en", (isGeneric ? "generic" : "constraint"), resourceName);
                string requestedResourceKey = string.Format("{0}_{1}_{2}", (isGeneric ? "generic" : "constraint"), resourceName, language);

                //Get default english transalation for requested resource
                resourceValueInEnglish = await _redisDBInstance.StringGetAsync(new RedisKey(defaultEnglishResourceKey));

                if (_redisDBInstance.KeyExists(requestedResourceKey))
                {
                    string resourceValue = await _redisDBInstance.StringGetAsync(requestedResourceKey);

                    //If requested key exists in Redis Db then return respective resource value else return  
                    //default english translation of requested resource key suffix with ?

                    return !string.IsNullOrEmpty(resourceValue) ? resourceValue : string.Format("{0}?", resourceValueInEnglish);
                }
                else
                {
                    //If requested key not exists in Redis Db then return default 
                    //english translation of requested resource key suffix with ??

                    return string.Format("{0}??", resourceName);
                }
            }
            catch (Exception ex)
            {
                // In case of any exception assuming no key found and return default english translation of requested resource key suffix with ??
                _logger.LogError($"RedisDbClientHelper ::: GetLanguageResourceValue :: Exception : {ex.Message}");
                return string.Format("{0}?", resourceValueInEnglish);
            }
        }

        public async Task<string> GetTranslationForDynamicContent(string message, string target_language)
        {
            try
            {
                var httpClient = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}", "RedisService"));

                var content = JsonConvert.SerializeObject(new TranslateItem { TargetLanguageCode = target_language, Text = message });

                request.Content = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                var apiRestResponse = response.Adapt<ApiResponseResult>();

                if (apiRestResponse.IsSuccessStatusCode)
                {
                    var translatedData = JsonConvert.DeserializeObject<TranslateItem>(apiRestResponse.Data.ToString());

                    return translatedData.Text;
                }

                return $"{message}??";
            }
            catch (Exception ex)
            {
                // In case of any exception assuming no key found and return default english translation of requested resource key suffix with ??
                _logger.LogError($"RedisDbClientHelper ::: GetTranslationForDynamicContent :: Exception : {ex.Message}");
                return $"{message}??";
            }
        }
    }
}
