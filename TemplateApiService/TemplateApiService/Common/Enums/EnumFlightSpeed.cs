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
    public enum EnumFlightSpeed
    {
        /// <summary>
        /// Miles per hour.
        /// </summary>
        [Description(nameof(MPH)), EnumMember(Value = "MPH")]
        MPH = 1,

        /// <summary>
        /// Meters per seconds.
        /// </summary>
        [Description(nameof(MPS)), EnumMember(Value = "MPS")]
        MPS = 2
    }
}
