using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumOperationCategory
    {
        /// <summary>
        /// AREA_BASED
        /// </summary>
        [Description(nameof(AREA_BASED)), EnumMember(Value = "AREA_BASED")]
        AREA_BASED = 1,

        /// <summary>
        /// POLY_GRID
        /// </summary>
        [Description(nameof(POLY_GRID)), EnumMember(Value = "POLY_GRID")]
        POLY_GRID = 2,

        /// <summary>
        /// LINE_STRING
        /// </summary>
        [Description(nameof(LINE_STRING)), EnumMember(Value = "LINE_STRING")]
        LINE_STRING = 3,

        /// <summary>
        /// DELIVERY
        /// </summary>
        [Description(nameof(DELIVERY)), EnumMember(Value = "DELIVERY")]
        DELIVERY = 4,

        /// <summary>
        /// TORNADO
        /// </summary>
        [Description(nameof(TORNADO)), EnumMember(Value = "TORNADO")]
        TORNADO = 5,

        /// <summary>
        /// COLUMNAR
        /// </summary>
        [Description(nameof(COLUMNAR)), EnumMember(Value = "COLUMNAR")]
        COLUMNAR = 6,

        /// <summary>
        /// FACADE
        /// </summary>
        [Description(nameof(FACADE)), EnumMember(Value = "FACADE")]
        FACADE = 7
    }
}
