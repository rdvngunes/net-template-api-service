using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum DegreeOfUrbanization
    {     /// <summary>
          /// VLOS
          /// </summary>
        [Description(nameof(URBAN)), EnumMember(Value = "Urban")]
        URBAN = 1,

        /// <summary>
        /// BVLOS
        /// </summary>
        [Description(nameof(RURAL)), EnumMember(Value = "Rural")]
        RURAL = 2
    }

}
