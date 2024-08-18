using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.Common.RedisDbClient
{
    public class TranslateItem
    {   /// <summary>
        /// Source Language Code
        /// </summary>
        [DataMember(Name = "source_language_code", EmitDefaultValue = false)]
        [JsonPropertyName("source_language_code")]
        [Required]
        public string SourceLanguageCode { get; set; } = "en";

        /// <summary>
        /// Target Language Code
        /// </summary>
        [DataMember(Name = "target_language_code", EmitDefaultValue = false)]
        [JsonPropertyName("target_language_code")]
        [Required]
        public string TargetLanguageCode { get; set; } = "en";

        /// <summary>
        /// Message to translate
        /// </summary>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        [JsonPropertyName("text")]
        [Required]
        public string Text { get; set; }
    }
}
