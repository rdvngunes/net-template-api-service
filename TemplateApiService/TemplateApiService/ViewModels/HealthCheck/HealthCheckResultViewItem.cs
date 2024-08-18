using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.HealthCheck
{
    [DataContract]
    public class HealthCheckResultViewItem
    {
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [DataMember(Name = "Ip", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Ip")]
        public string Ip { get; set; }

        [DataMember(Name = "service_name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "service_name")]
        public string ServiceName { get; set; }

        [DataMember(Name = "total_memory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "total_memory")]
        public string TotalMemory { get; set; }

        [DataMember(Name = "memory_usage", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "memory_usage")]
        public string MemoryUsage { get; set; }

        [DataMember(Name = "disk_allocated", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "disk_allocated")]
        public string DiskAllocated { get; set; }

        [DataMember(Name = "disk_usage", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "disk_usage")]
        public string DiskUsage { get; set; }

        [DataMember(Name = "cpu_utilization", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cpu_utilization")]
        public string CpuUtilization { get; set; }

        [DataMember(Name = "result", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "result")]
        public List<HealthCheckItem> Result { get; set; }
    }
}
