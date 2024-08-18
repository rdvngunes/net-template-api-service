using Jal.HttpClient.Impl;
using Jal.HttpClient.Interface;
using Jal.HttpClient.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApiService.Common.SoraHttpClient
{
    public class HttpClientHelper
    {
        private readonly ILogger<HttpClientHelper> _logger;
        private IHttpHandler _httpClient;

        /// <summary>
        /// FlightAuth Http client constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="httpClientLogger"></param>
        public HttpClientHelper(ILogger<HttpClientHelper> logger, HttpClientLogger httpClientLogger)
        {
            _logger = logger;
            _httpClient = HttpHandler.Builder.Create;
            _httpClient.Interceptor = httpClientLogger;
        }

        /// <summary>
        /// Post request.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Post<T>(string url, object data, string accessToken = null)
        {
            try
            {
                var request = new HttpRequest(url, Jal.HttpClient.Model.HttpMethod.Post);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.Add(new HttpHeader("authorization", accessToken));
                }

                request.Content = new HttpRequestStringContent(Serialize(data))
                {
                    ContentType = "application/json"
                };

                var response = _httpClient.Send(request);

                //Ensure the success request and response.
                if (response.Exception == null)
                {
                    var content = response.Content.Read();

                    return Deserialize(content, typeof(T));
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception::: HttpClientHelper :: url = {url}");
                _logger.LogError($"Exception::: HttpClientHelper :: exception = {ex}");

                return null;
            }
        }

        /// <summary>
        /// Get Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public object Get<T>(string url, string accessToken = null)
        {
            try
            {
                var request = new HttpRequest(url, Jal.HttpClient.Model.HttpMethod.Get);
                var requestTime = DateTime.UtcNow;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.Add(new HttpHeader("authorization", accessToken));
                }

                request.Content.ContentType = "application/json";
                request.Content.CharacterSet = "charset=utf-8";

                using (var response = _httpClient.Send(request))
                {
                    var content = response.Content.Read();

                    return Deserialize(content, typeof(T));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception::: HttpClientHelper :: url = {url}");
                _logger.LogError($"Exception::: HttpClientHelper :: exception = {ex}");

                return null;
            }
        }

        /// <summary>
        /// GET Async http request handler
        /// </summary>
        /// <param name="url"></param>
        /// <param name="authorization"></param>
        /// <returns></returns>
        public async Task<object> GetAsync<T>(string url, string authorization)
        {
            var request = new System.Net.Http.HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = System.Net.Http.HttpMethod.Get
            };

            var client = new System.Net.Http.HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorization.Remove(0, 6));

            var response = client.SendAsync(request).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            return Deserialize(content, typeof(T));
        }

        private string Serialize(object obj)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            serializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            return obj != null ? JsonConvert.SerializeObject(obj, Formatting.Indented, serializerSettings) : string.Empty;
        }


        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="content">HTTP body (e.g. string, JSON).</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public object Deserialize(string content, Type type)
        {
            if (type == typeof(Object)) // return an object
            {
                return content;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(content, null, System.Globalization.DateTimeStyles.AssumeUniversal);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(content, type);
            }
            catch (IOException)
            {
                throw;
            }
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// Ref: http://stackoverflow.com/questions/4925718/c-dynamic-runtime-cast
        /// </summary>
        /// <param name="source">Object to be casted</param>
        /// <param name="dest">Target type</param>
        /// <returns>Casted object</returns>
        public static Object ConvertType(Object source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }
    }
}
