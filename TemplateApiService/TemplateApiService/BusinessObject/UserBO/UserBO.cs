using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateApiService.Common.RedisDbClient;
using TemplateApiService.Common.RestClient;
using TemplateApiService.Common.Security;
using TemplateApiService.Data;
using TemplateApiService.Models.Users;
using TemplateApiService.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateApiService.Common.Enums;

namespace TemplateApiService.BusinessObject.UsersBO
{
    public class UsersBO : IUsersBO
    {
        private readonly IDbRepository<User> _UsersRepository;
        private readonly ErrorResponseHelper _errorResponseHelper;
        private readonly ILogger<UsersBO> _logger;
        private readonly LanguageTranslationHelper _languageTranslationHelper;
        private readonly AuthorizationClaimsProvider _authorizationClaimsProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="logger"></param>
        /// <param name="authorizationClaimsProvider"></param>
        /// <param name="languageTranslationHelper"></param>
        /// <param name="errorResponseHelper"></param>
        /// <param name="databaseFunctions"></param>
        /// <param name="configuration"></param>
        public UsersBO(IDbRepository<User> userRepository,
            ILogger<UsersBO> logger,
            ErrorResponseHelper errorResponseHelper,
            LanguageTranslationHelper languageTranslationHelper,
            AuthorizationClaimsProvider authorizationClaimsProvider)
        {
            _UsersRepository = userRepository;
            _logger = logger;
            _errorResponseHelper = errorResponseHelper;
            _languageTranslationHelper = languageTranslationHelper;
            _authorizationClaimsProvider = authorizationClaimsProvider;
        }

        /// <summary>
        /// Get user data listing
        /// </summary>
        /// <param name="query">Query parameters for user data filter</param>
        /// <returns>Returns list of users.</returns>
        public async Task<IActionResult> GetUsersByBrand(Guid brandId, Guid typeId)
        {
            var result = new ApiRestResponseResult();

            var User = _UsersRepository.GetAll()
                            .Where(x => !x.IsDeleted).FirstOrDefault();

            var userListItems = User.Adapt<UsersViewModel>();

            result.Status = EnumHttpStatusCode.success;
            result.Data = userListItems;

            return result.Adapt<ObjectResult>();
        }

        public async Task<IActionResult> CreateUsers(UsersViewModel userItem)
        {

            ApiRestResponseResult result = new ApiRestResponseResult();
            try
            {
                var currentUserId = _authorizationClaimsProvider.GetCurrentUserId();
                var user = userItem.Adapt<User>();

                _UsersRepository.Add(user);

                result.StatusCode = StatusCodes.Status201Created;

                string transaletedMessage = await _languageTranslationHelper.GetTranslation("User Created");

                result.Data = new SuccessViewModel(user?.UserId.ToString(), "");

                return result.Adapt<ObjectResult>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception :::: UserBO ::: CreateUser :: ex = {ex.Message}");

                var errorResult = await _errorResponseHelper.GetErrorResult(StatusCodes.Status500InternalServerError);

                return errorResult.Adapt<ObjectResult>();
            }
        }

        /// <summary>
        /// Get user data listing
        /// </summary>
        /// <param name="query">Query parameters for user data filter</param>
        /// <returns>Returns list of users.</returns>
    
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var result = new ApiRestResponseResult();
            UsersViewModel user = User(userId);

            result.Status = EnumHttpStatusCode.success;
            result.Data = user;

            return result.Adapt<ObjectResult>();
        }

        public UsersViewModel User(Guid userId)
        {
            UsersViewModel UsersViewModel = new UsersViewModel();

            var user = _UsersRepository.GetAll()
                            .Where(x => x.UserId == userId).FirstOrDefault();
            UsersViewModel = user.Adapt<UsersViewModel>();

            return UsersViewModel;
        }

        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            ApiRestResponseResult result = new ApiRestResponseResult();

            try
            {
                if (userId.Equals(Guid.Empty))
                {
                    // Get Language Transalation
                    string transaletedMessage = await _languageTranslationHelper.GetTranslation(EnumGenericLanguageResources.primary_key_value_required.ToString(), true);

                    result.StatusCode = StatusCodes.Status400BadRequest;
                    result.Status = EnumHttpStatusCode.error;
                    result.Error = new ErrorViewModel(new List<string> { transaletedMessage });

                    return result.Adapt<ObjectResult>();
                }
                else
                {
                    var user = _UsersRepository.Find(userId);

                    if (user != null)
                    {
                        _UsersRepository.Remove(userId);

                        // Get Language Transalation
                        string transaletedMessage = await _languageTranslationHelper.GetTranslation(EnumUserLanguageResources.user_deleted.ToString());

                        result.Data = new SuccessViewModel(userId.ToString(), transaletedMessage);

                        return result.Adapt<ObjectResult>();
                    }
                    else
                    {
                        var errorResult = await _errorResponseHelper.GetErrorResult(StatusCodes.Status404NotFound);

                        return errorResult.Adapt<ObjectResult>();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception :::: UserBO ::: DeleteUser :: ex = {ex.Message}");

                var errorResult = await _errorResponseHelper.GetErrorResult(StatusCodes.Status500InternalServerError);

                return errorResult.Adapt<ObjectResult>();
            }
        }
        public async Task<IActionResult> UpdateUser(UsersUpdateModel userItem)
        {
            ApiRestResponseResult result = new ApiRestResponseResult();

            try
            {
                if (userItem.UserId.Equals(Guid.Empty))
                {
                    string transaletedMessage = await _languageTranslationHelper.GetTranslation(EnumGenericLanguageResources.primary_key_value_required.ToString(), true);
                    result.StatusCode = StatusCodes.Status400BadRequest;
                    result.Status = EnumHttpStatusCode.error;
                    result.Error = new ErrorViewModel(new List<string> { transaletedMessage });
                    return new BadRequestObjectResult(result);
                }
                else
                {
                    var user = _UsersRepository.Find(userItem.UserId);

                    if (user != null)
                    {
                        userItem.Adapt(user);
                        _UsersRepository.Update(user);

                        // Get Language Transalation
                        string transaletedMessage = await _languageTranslationHelper.GetTranslation(EnumUserLanguageResources.user_updated.ToString());

                        result.Data = new SuccessViewModel(user?.UserId.ToString(), transaletedMessage);

                        return result.Adapt<ObjectResult>();
                    }
                    else
                    {
                        var errorResult = await _errorResponseHelper.GetErrorResult(StatusCodes.Status404NotFound);

                        return errorResult.Adapt<ObjectResult>();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception :::: UserBO ::: UpdateUser :: ex = {ex.Message}");

                var errorResult = await _errorResponseHelper.GetErrorResult(StatusCodes.Status500InternalServerError);

                return errorResult.Adapt<ObjectResult>();
            }
        }
    }
}
