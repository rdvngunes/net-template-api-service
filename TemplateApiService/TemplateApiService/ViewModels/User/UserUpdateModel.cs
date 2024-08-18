
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
        [JsonPropertyName("User_Id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("Is_Active")]
        public bool IsActive { get; set; }
    
    }
}