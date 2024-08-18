using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Validation
{
    public class ValidationError
    {
        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public List<string> Message { get; }

        public ValidationError(List<string> messages)
        {
            Message = messages;
        }
    }
}
