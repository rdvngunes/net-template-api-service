using Microsoft.AspNetCore.Http;
using TemplateApiService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RestClient
{
    public class ApiRestResponseResult
    {
        /// <summary>
        /// Gets or Sets Api Version
        /// </summary>
        [DataMember(Name = "api_version", EmitDefaultValue = false)]
        [JsonPropertyName("api_version")]
        public string ApiVersion { get; set; } = "1.0";

        /// <summary>
        /// Gets or Sets HttpStatus
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonPropertyName("status")]
        public EnumHttpStatusCode Status { get; set; } = EnumHttpStatusCode.success;

        /// <summary>
        /// Gets or Sets Success Content
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        [JsonPropertyName("data")]
        public object Data { get; set; }

        /// <summary>
        /// Gets or Sets Error Content
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        [JsonPropertyName("error")]
        public object Error { get; set; }

        /// <summary>
        /// Gets or Sets Http Status Code
        /// </summary>
        [JsonPropertyName("status_code")]
        [JsonIgnore]
        public int StatusCode { get; set; } = (int)StatusCodes.Status200OK;

        /// <summary>
        /// Gets or Sets Http Response Content
        /// </summary>
        [JsonPropertyName("content")]
        [JsonIgnore]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Http Response Success Flag
        /// </summary>
        [JsonPropertyName("is_success_status_code")]
        [JsonIgnore]
        public bool IsSuccessStatusCode { get; set; } = true;
    }
}
