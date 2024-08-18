
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
        [JsonPropertyName("User_Id")]
        public Guid UserId { get; set; }
    }
}
