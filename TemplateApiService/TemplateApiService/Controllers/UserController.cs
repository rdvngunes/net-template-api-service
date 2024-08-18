using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateApiService.BusinessObject.UsersBO;
using TemplateApiService.Common.RestClient;
using TemplateApiService.Common.Validation;
using TemplateApiService.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Controllers
{
    [Route(@"api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUsersBO _UsersBO;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUsersBO UsersBO)
        {
            _logger = logger;
            _UsersBO = UsersBO;

        }


        [HttpPost, ApiValidationFilterAttribute]
        [Route(@"/User")]
        [Authorize]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> PostUserharacteristics([FromBody] UsersViewModel inputDto)
        {
            return await _UsersBO.CreateUsers(inputDto);
        }

        [HttpGet]
        //[Authorize]
        [Route(@"/User/{userId}/details")]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> GetUser([FromRoute] string userId)
        {
            return await _UsersBO.GetUser(new Guid(userId));
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <response code="200">User deleted.</response>
        /// <response code="401">Invalid or missing access_token provided.</response>
        /// <response code="403">The access token was decoded successfully but did not include a scope appropriate to this endpoint.</response>
        /// <response code="404">Resource not found.</response>
        /// <response code="429">Too many recent requests from you. Wait to make further submissions.</response>
        [HttpDelete]
        //[Authorize]
        [Route(@"/User/{userId}")]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> DeleteUserInstance([FromRoute] Guid userId)
        {
            return await _UsersBO.DeleteUser(userId);
        }

        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <param name="userItem">The user data</param>
        /// <response code="200">User details updated.</response>
        /// <response code="400">Bad request. Typically validation error. Fix your request and retry.</response>
        /// <response code="401">Invalid or missing access_token provided.</response>
        /// <response code="403">The access token was decoded successfully but did not include a scope appropriate to this endpoint.</response>
        /// <response code="404" > Resource not found.</response>
        /// <response code="429">Too many recent requests from you. Wait to make further submissions.</response>
        [HttpPut]
        //[Authorize]
        [Route(@"/users")]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiRestResponseResult), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> UpdateUserInstance([FromBody] UsersUpdateModel userItem)
        {
            return await _UsersBO.UpdateUser(userItem);
        }

    }
}
