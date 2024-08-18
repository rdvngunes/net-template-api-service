using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CharacteristicDimensionUnit
        {
            [Description(nameof(m)), EnumMember(Value = "m")]
            m = 1,
            [Description(nameof(mm)), EnumMember(Value = "mm")]
            mm = 2,
            [Description(nameof(cm)), EnumMember(Value = "cm")]
            cm = 3,
            [Description(nameof(ft)), EnumMember(Value = "ft")]
            ft = 4,
            [Description(nameof(inc)), EnumMember(Value = "in")]
            inc = 5,
        }
    }
