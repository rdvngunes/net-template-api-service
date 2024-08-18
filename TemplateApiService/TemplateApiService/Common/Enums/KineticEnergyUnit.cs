using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KineticEnergyUnit
    {
        [Description(nameof(J)), EnumMember(Value = "J")]
        J = 1,
        [Description(nameof(kJ)), EnumMember(Value = "kJ")]
        kJ = 2,
        [Description(nameof(ft)), EnumMember(Value = "ft")]
        ft = 3,
        [Description(nameof(lbf)), EnumMember(Value = "lbf")]
        lbf = 4,
    }
}
