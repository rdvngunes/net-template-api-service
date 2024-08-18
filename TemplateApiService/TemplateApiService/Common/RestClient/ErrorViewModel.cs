using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RestClient
{
    public class ErrorViewModel
    {  /// <summary>
       /// Gets or Sets Message
       /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "message")]
        public List<string> Message { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="messages"></param>
        public ErrorViewModel(List<string> messages)
        {
            Message = messages;
        }

    }
}
