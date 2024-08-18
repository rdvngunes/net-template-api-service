using TemplateApiService.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.Users
{
    public class UsersViewModel
    {
        [JsonPropertyName("User_Characteristic_Id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("Brand_Name")]
        public string BrandName { get; set; }
        [JsonPropertyName("Type_Name")]
        public string TypeName { get; set; }

        [JsonPropertyName("Kinetic_Energy")]
        public double KineticEnergy { get; set; }

        [JsonPropertyName("Kinetic_Energy_Unit")]
        public KineticEnergyUnit KineticEnergyUnit { get; set; }

        [JsonPropertyName("Maximum_TakeOff_Mass")]
        public double MaximumTakeOffMass { get; set; }

        [JsonPropertyName("Maximum_TakeOff_Mas_Unit")]
        public MaximumTakeOffMassUnit MaximumTakeOffMassUnit { get; set; }

        [JsonPropertyName("Characteristic_Speed")]
        public double CharacteristicSpeed { get; set; }

        [JsonPropertyName("Characteristic_Speed_Unit")]
        public CharacteristicSpeedUnit CharacteristicSpeedUnit { get; set; }

        [JsonPropertyName("Characteristic_Dimension")]
        public double CharacteristicDimension { get; set; }
        [JsonPropertyName("Characteristic_Dimension_Unit")]
        public CharacteristicDimensionUnit CharacteristicDimensionUnit { get; set; }

        [JsonPropertyName("Ground_Risk_Category")]
        public int GroundRiskCategory { get; set; }

        [JsonPropertyName("Comment")]
        public string Comment { get; set; }

        [JsonPropertyName("Source")]
        public string Source { get; set; }
    }
}
