using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RestClient
{
    public class SuccessViewModel
    { /// <summary>
      /// Gets or Sets Id
      /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public string Id { get; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        [JsonPropertyName("message")]
        public string Message { get; }

        public SuccessViewModel(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
