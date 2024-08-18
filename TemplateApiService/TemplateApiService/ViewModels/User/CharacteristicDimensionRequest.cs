using TemplateApiService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.Users
{
    public class CharacteristicDimensionRequest
    {
        [JsonPropertyName("Kinetic_Energy")]
        public double KineticEnergy { get; set; }

        [JsonPropertyName("Kinetic_Energy_Unit")]
        public KineticEnergyUnit KineticEnergyUnit { get; set; }

        [JsonPropertyName("Characteristic_Dimension")]
        public double CharacteristicDimension { get; set; }
        [JsonPropertyName("Characteristic_Dimension_Unit")]
        public CharacteristicDimensionUnit CharacteristicDimensionUnit { get; set; }
    }
}
