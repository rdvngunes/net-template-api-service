using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TemplateApiService.Common.Enums
{
    /// <summary>
    /// EnumFlightType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumFlightType
    {
        /// <summary>
        /// SPECIAL_OPERATIONS
        /// </summary>
        [Description(nameof(SPECIAL_OPERATIONS)), EnumMember(Value = "SPECIAL_OPERATIONS")]
        SPECIAL_OPERATIONS = 1,

        /// <summary>
        /// CARGO_OPERATIONS
        /// </summary>
        [Description(nameof(CARGO_OPERATIONS)), EnumMember(Value = "CARGO_OPERATIONS")]
        CARGO_OPERATIONS = 2,

        /// <summary>
        /// PASSENGER_OPERATIONS
        /// </summary>
        [Description(nameof(PASSENGER_OPERATIONS)), EnumMember(Value = "PASSENGER_OPERATIONS")]
        PASSENGER_OPERATIONS = 3,

        /// <summary>
        /// OTHERS
        /// </summary>
        [Description(nameof(OTHERS)), EnumMember(Value = "OTHERS")]
        OTHERS = 4,

        /// <summary>
        /// AIRSPACE_SIMULATION
        /// </summary>
        [Description(nameof(AIRSPACE_SIMULATION)), EnumMember(Value = "AIRSPACE_SIMULATION")]
        AIRSPACE_SIMULATION = 5,

        /// <summary>
        /// FLIGHT_SIMULATION
        /// </summary>
        [Description(nameof(FLIGHT_SIMULATION)), EnumMember(Value = "FLIGHT_SIMULATION")]
        FLIGHT_SIMULATION = 6,

        /// <summary>
        /// LIVE_FLIGHT
        /// </summary>
        [Description(nameof(LIVE_FLIGHT)), EnumMember(Value = "LIVE_FLIGHT")]
        LIVE_FLIGHT = 7,

        /// <summary>
        /// SIM_OPERATIONS
        /// </summary>
        [Description(nameof(SIM_OPERATIONS)), EnumMember(Value = "SIM_OPERATIONS")]
        SIM_OPERATIONS = 8
    }
}


