using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumOperationState
    {
        /// <summary>
        /// Planning
        /// </summary>
        [Description(nameof(Planning)), EnumMember(Value = "Planning")]
        Planning = 0,

        /// <summary>
        /// Conflicted
        /// </summary>
        [Description(nameof(Conflicted)), EnumMember(Value = "Conflicted")]
        Conflicted = 1,

        /// <summary>
        /// ReadyForApproval
        /// </summary>
        [Description(nameof(ReadyForApproval)), EnumMember(Value = "ReadyForApproval")]
        ReadyForApproval = 2,

        /// <summary>
        /// Accepted
        /// </summary>
        [Description(nameof(Accepted)), EnumMember(Value = "Accepted")]
        Accepted = 3,

        /// <summary>
        /// Activated
        /// </summary>
        [Description(nameof(Activated)), EnumMember(Value = "Activated")]
        Activated = 4,

        /// <summary>
        /// NonConforming
        /// </summary>
        [Description(nameof(NonConforming)), EnumMember(Value = "NonConforming")]
        NonConforming = 5,

        /// <summary>
        /// Contingent
        /// </summary>
        [Description(nameof(Contingent)), EnumMember(Value = "Contingent")]
        Contingent = 6,

        /// <summary>
        /// Ended
        /// </summary>
        [Description(nameof(Ended)), EnumMember(Value = "Ended")]
        Ended = 7,

        /// <summary>
        /// Rescinded
        /// </summary>
        [Description(nameof(Rescinded)), EnumMember(Value = "Rescinded")]
        Rescinded = 8,

        /// <summary>
        /// Canceled
        /// </summary>
        [Description(nameof(Canceled)), EnumMember(Value = "Canceled")]
        Canceled = 9,

        /// <summary>
        /// Denied
        /// </summary>
        [Description(nameof(Denied)), EnumMember(Value = "Denied ")]
        Denied = 10,

        /// <summary>
        /// Pending
        /// </summary>
        [Description(nameof(Invalid)), EnumMember(Value = "Invalid")]
        Invalid = 11
    }

}
