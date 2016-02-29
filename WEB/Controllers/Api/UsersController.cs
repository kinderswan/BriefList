using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Interfaces.Interfaces;
using WEB.Mapping;
using WEB.Models.ApiModels;

namespace WEB.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userService;
        private readonly IListService _listService;
        private readonly IItemService _itemService;

        public UsersController() { }

        public UsersController(IUserProfileService userProfileService, IListService listService, IItemService itemService)
        {
            _userService = userProfileService;
            _listService = listService;
            _itemService = itemService;
        }

        #region get
        [HttpGet]
        [Route("api/users")]
        public async Task<IEnumerable<ApiUserProfile>> GetUsers()
        {
            return (await _userService.GetUserProfiles()).Select(Mapper.ToApiUserProfile);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public async Task<ApiUserProfile> GetUser(int id)
        {
            return Mapper.ToApiUserProfile(await _userService.GetUserProfile(id));
        }

        [HttpGet]
        [Route("api/users/{name}")]
        public async Task<ApiUserProfile> GetUser(string name)
        {
            return Mapper.ToApiUserProfile(await _userService.GetUserProfile(name));
        }

        
        

        
        //todo: add /id to get controllers
        #endregion

        #region delete

        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userService.DeleteUserProfile(id);
        }

        #endregion

        #region post
        
        #endregion
    }
}
