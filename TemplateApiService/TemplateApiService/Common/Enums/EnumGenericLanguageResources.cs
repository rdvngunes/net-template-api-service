using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumGenericLanguageResources
    {
        /// <summary>
        /// no_data_found
        /// </summary>
        [EnumMember(Value = "No data found. Please try again.")]
        no_data_found = 1,

        /// <summary>
        /// primary_key_value_not_required
        /// </summary>
        [EnumMember(Value = "Primary key value is not required.")]
        primary_key_value_not_required = 2,

        /// <summary>
        /// primary_key_value_not_required
        /// </summary>
        [EnumMember(Value = "Primary key value is required.")]
        primary_key_value_required = 3,

        /// <summary>
        /// internal_error
        /// </summary>
        [EnumMember(Value = "Internal error. Please contact system administrator.")]
        internal_error = 4,

        /// <summary>
        /// invalid_user_role
        /// </summary>
        [EnumMember(Value = "Invalid user Role. This user doesn't have the right access.")]
        invalid_user_role = 5,

        /// <summary>
        /// invalid_route_param_id
        /// </summary>
        [EnumMember(Value = "Primary key value of requested entity not matched with route parameter id.")]
        invalid_route_param_id = 6,

        /// <summary>
        /// required_ansp_id
        /// </summary>
        [EnumMember(Value = "Ansp Id field required.")]
        required_ansp_id = 7,

        /// <summary>
        /// required_user_id
        /// </summary>
        [EnumMember(Value = "User Id field required.")]
        required_user_id = 8,

        /// <summary>
        /// invalid_ansp_id
        /// </summary>
        [EnumMember(Value = "Ansp Id is not of the correct UUID version 4.")]
        invalid_ansp_id = 9,

        /// <summary>
        /// invalid_user_id
        /// </summary>
        [EnumMember(Value = "User Id is not of the correct UUID version 4.")]
        invalid_user_id = 10,

        /// <summary>
        /// http_status_code_401
        /// </summary>
        [EnumMember(Value = "Invalid or missing access token provided.")]
        http_status_code_401 = 11,

        /// <summary>
        /// http_status_code_403
        /// </summary>
        [EnumMember(Value = "The access token was decoded successfully but did not include a scope appropriate to this endpoint.")]
        http_status_code_403 = 12,

        /// <summary>
        /// http_status_code_429
        /// </summary>
        [EnumMember(Value = "Too many recent requests from you. Wait to make further queries.")]
        http_status_code_429 = 13,

        /// <summary>
        /// http_status_code_500
        /// </summary>
        [EnumMember(Value = "Internal error. Please contact system administrator.")]
        http_status_code_500 = 14,

        /// <summary>
        /// no_user_found
        /// </summary>
        [EnumMember(Value = "User not found.")]
        no_user_found = 15,
    }
}
