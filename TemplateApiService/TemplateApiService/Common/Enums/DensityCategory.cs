using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DensityCategory
    {
        [Description(nameof(Sparsely_Populated)), EnumMember(Value = "Sparsely Populated")]
        Sparsely_Populated = 1, 
        [Description(nameof(Populated)), EnumMember(Value = "Populated")]
        Populated = 2,
        [Description(nameof(Gathering_Of_People)), EnumMember(Value = "Gathering Of People")]
        Gathering_Of_People = 3,
    }
}
