using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaximumTakeOffMassUnit
    {
        [Description(nameof(kg)), EnumMember(Value = "kg")]
        kg = 1,
        [Description(nameof(g)), EnumMember(Value = "g")]
        g = 2,
        [Description(nameof(lb)), EnumMember(Value = "lb")]
        lb = 3,
    }
}
