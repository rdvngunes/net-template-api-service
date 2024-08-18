using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumFlightCategory
    {
        /// <summary>
        /// OPEN
        /// </summary>
        [Description(nameof(OPEN)), EnumMember(Value = "OPEN")]
        OPEN = 1,

        /// <summary>
        /// SPECIFIC
        /// </summary>
        [Description(nameof(SPECIFIC)), EnumMember(Value = "SPECIFIC")]
        SPECIFIC = 2,

        /// <summary>
        /// CERTIFIED
        /// </summary>
        [Description(nameof(CERTIFIED)), EnumMember(Value = "CERTIFIED")]
        CERTIFIED = 3
    }
}
