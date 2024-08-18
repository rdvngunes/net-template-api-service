using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Mitigation
    {
        [Description(nameof(N)), EnumMember(Value = "N")]
        N = 1,
        [Description(nameof(L)), EnumMember(Value = "Low")]
        L = 2,
        [Description(nameof(M)), EnumMember(Value = "Medium")]
        M = 3,
        [Description(nameof(H)), EnumMember(Value = "High")]
        H = 4,
    }
}
