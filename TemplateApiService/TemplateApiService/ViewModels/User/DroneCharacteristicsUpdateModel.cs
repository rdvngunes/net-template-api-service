using TemplateApiService.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TemplateApiService.ViewModels.Users
{
    public class UsersUpdateModel
    {
        [JsonPropertyName("User_Characteristic_Id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("Is_Active")]
        public bool IsActive { get; set; }
    
        [JsonPropertyName("Brand_Id")]
        public Guid BrandId { get; set; }

        [JsonPropertyName("Type_Id")]
        public Guid TypeId { get; set; }

        [JsonPropertyName("Kinetic_Energy")]
        public double KineticEnergy { get; set; }

        [JsonPropertyName("Kinetic_Energy_Unit")]
        public string KineticEnergyUnit { get; set; }

        [JsonPropertyName("Maximum_TakeOff_Mass")]
        public double MaximumTakeOffMass { get; set; }

        [JsonPropertyName("Maximum_TakeOff_Mas_Unit")]
        public string MaximumTakeOffMassUnit { get; set; }

        [JsonPropertyName("Characteristic_Speed")]
        public double CharacteristicSpeed { get; set; }

        [JsonPropertyName("Characteristic_Speed_Unit")]
        public string CharacteristicSpeedUnit { get; set; }

        [JsonPropertyName("Characteristic_Dimension")]
        public double CharacteristicDimension { get; set; }

        [JsonPropertyName("Characteristic_Dimension_Unit")]
        public string CharacteristicDimensionUnit { get; set; }

        [JsonPropertyName("Ground_Risk_Category")]
        public int GroundRiskCategory { get; set; }

        [JsonPropertyName("Comment")]
        public string Comment { get; set; }

        [JsonPropertyName("Source")]
        public string Source { get; set; }
    }
}