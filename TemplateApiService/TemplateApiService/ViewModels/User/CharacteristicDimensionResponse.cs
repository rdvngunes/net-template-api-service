using TemplateApiService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.Users
{
    public class CharacteristicDimensionResponse
    {
        [JsonPropertyName("Kinetic_Energy1")]
        public double KineticEnergy1 { get; set; }
        [JsonPropertyName("Kinetic_Energy2")]
        public double KineticEnergy2 { get; set; }

        [JsonPropertyName("Kinetic_Energy_Unit")]
        public KineticEnergyUnit KineticEnergyUnit { get; set; }

        [JsonPropertyName("Characteristic_Dimension1")]
        public double CharacteristicDimension1 { get; set; }
        [JsonPropertyName("Characteristic_Dimension2")]
        public double CharacteristicDimension2 { get; set; }
        [JsonPropertyName("Characteristic_Dimension_Unit")]
        public CharacteristicDimensionUnit CharacteristicDimensionUnit { get; set; }

        [JsonPropertyName("match")]
        public bool match { get; set; }
    }
}
