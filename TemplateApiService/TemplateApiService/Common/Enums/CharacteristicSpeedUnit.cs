using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CharacteristicSpeedUnit
    {
        [Description(nameof(ms)), EnumMember(Value = "m/s")]
        ms = 1,
        [Description(nameof(kmh)), EnumMember(Value = "km/h")]
        kmh = 2,
        [Description(nameof(mph)), EnumMember(Value = "mph")]
        mph = 3,
        [Description(nameof(kt)), EnumMember(Value = "kt")]
        kt   = 4,
        [Description(nameof(fts)), EnumMember(Value = "fts")]
        fts = 5,
    }
}
