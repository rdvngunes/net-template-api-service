using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AirSpaceContext
    {
        [Description(nameof(Controlled_Airspace)), EnumMember(Value = "Controlled Airspace")]
        Controlled_Airspace = 1, 
        [Description(nameof(TMZ)), EnumMember(Value = "TMZ")]
        TMZ = 2,
        [Description(nameof(Airport_Environment)), EnumMember(Value = " Airport Environment")]
        Airport_Environment = 3,
        [Description(nameof(Heliport_Environment)), EnumMember(Value = " Heliport Environment")]
        Heliport_Environment = 4,
        [Description(nameof(Uncontrolled_Airspace)), EnumMember(Value = "Uncontrolled Airspace")]
        Uncontrolled_Airspace = 5,

    }
}
