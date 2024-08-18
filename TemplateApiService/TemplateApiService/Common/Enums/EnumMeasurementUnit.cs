using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumMeasurementUnit
    {
        /// <summary>
        /// Meter
        /// </summary>
        [Description(nameof(M)), EnumMember(Value = "M")]
        M = 1,

        /// <summary>
        /// Feet
        /// </summary>
        [Description(nameof(FT)), EnumMember(Value = "FT")]
        FT = 2
    }
}
