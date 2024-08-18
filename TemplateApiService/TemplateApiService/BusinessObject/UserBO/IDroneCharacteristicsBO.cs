using Microsoft.AspNetCore.Mvc;
using TemplateApiService.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateApiService.BusinessObject.UsersBO
{
    public interface IUsersBO
    {
        Task<IActionResult> GetUsersByBrand(Guid brandId, Guid typeId);
        Task<IActionResult> CreateUsers(UsersViewModel userItem);
        Task<IActionResult> GetUser(Guid userId);
        UsersViewModel User(Guid userId);
        Task<IActionResult> DeleteUser(Guid userId);

        Task<IActionResult> UpdateUser(UsersUpdateModel userItem);
    }
}
