using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TemplateApiService.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumUserLanguageResources
    {
        /// <summary>
        /// user_created
        /// </summary>
        [EnumMember(Value = "User created successfully.")]
        user_created = 1,

        /// <summary>
        /// user_updated
        /// </summary>
        [EnumMember(Value = "User updated successfully.")]
        user_updated = 2,

        /// <summary>
        /// user_deleted
        /// </summary>
        [EnumMember(Value = "User deleted successfully.")]
        user_deleted = 3,
    }
}
