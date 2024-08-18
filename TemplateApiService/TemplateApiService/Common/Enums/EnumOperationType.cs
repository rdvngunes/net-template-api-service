using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumOperationType
    {
        /// <summary>
        /// UNDEFINED
        /// </summary>
        [Description(nameof(UNDEFINED)), EnumMember(Value = "UNDEFINED")]
        UNDEFINED = 0,

        /// <summary>
        /// AA
        /// </summary>
        [Description(nameof(AA)), EnumMember(Value = "AA")]
        AA = 1,

        /// <summary>
        /// FC
        /// </summary>
        [Description(nameof(FC)), EnumMember(Value = "FC")]
        FC = 2,

        /// <summary>
        /// FCATC
        /// </summary>
        [Description(nameof(FCATC)), EnumMember(Value = "FCATC")]
        FCATC = 3,

    }

}
