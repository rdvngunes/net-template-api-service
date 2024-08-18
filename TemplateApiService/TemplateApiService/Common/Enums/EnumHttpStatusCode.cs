using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    /// <summary>
    /// EnumHttpStatusCode
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumHttpStatusCode
    {
        /// <summary>
        /// success
        /// </summary>
        [Description(nameof(success)), EnumMember(Value = "success")]
        success = 1,

        /// <summary>
        /// fail
        /// </summary>
        [Description(nameof(fail)), EnumMember(Value = "fail")]
        fail = 2,

        /// <summary>
        /// error
        /// </summary>
        [Description(nameof(error)), EnumMember(Value = "error")]
        error = 3,
    }
}
