using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateApiService.Common.Enums;

namespace TemplateApiService.Common.Validation
{
    public class ValidationResultModel
    {
        /// <summary>
        /// Gets or Sets Api Version
        /// </summary>
        [JsonProperty(PropertyName = "apiVersion")]
        public string ApiVersion { get; set; } = "1.0";

        /// <summary>
        /// Gets or Sets HttpStatus
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public EnumHttpStatusCode Status { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public ValidationError Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Status = EnumHttpStatusCode.error;
            Errors = new ValidationError(modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage))
                    .ToList());
        }
    }
}
