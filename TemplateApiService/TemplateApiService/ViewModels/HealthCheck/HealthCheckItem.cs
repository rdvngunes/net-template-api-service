using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.HealthCheck
{
    [DataContract]
    public class HealthCheckItem
    {
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
