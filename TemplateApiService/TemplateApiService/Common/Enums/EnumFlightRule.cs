using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    /// <summary>
    /// EnumFlightRule
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumFlightRule
    {
        /// <summary>
        /// VLOS
        /// </summary>
        [Description(nameof(VLOS)), EnumMember(Value = "VLOS")]
        VLOS = 1,

        /// <summary>
        /// BVLOS
        /// </summary>
        [Description(nameof(BVLOS)), EnumMember(Value = "BVLOS")]
        BVLOS = 2
    }

}
