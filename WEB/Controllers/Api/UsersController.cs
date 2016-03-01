using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Interfaces.BLLModels;
using BLL.Interfaces.Interfaces;
using Newtonsoft.Json;
using WEB.HelperExtension;
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
        public async Task<HttpResponseMessage> GetUsers()
        {
            var helper = new HttpResponseGetHelper<IEnumerable<ApiUserProfile>>(User.Identity.IsAuthenticated, Request);
            helper.Method( async ()=> (await _userService.GetUserProfiles()).Select(Mapper.ToApiUserProfile));
            return await helper.Result();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            var helper = new HttpResponseGetHelper<ApiUserProfile>(User.Identity.IsAuthenticated, Request);
            helper.Method( async () => Mapper.ToApiUserProfile(await _userService.GetUserProfile(id)));
            return await helper.Result();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUser(string name)
        {
            var helper = new HttpResponseGetHelper<ApiUserProfile>(User.Identity.IsAuthenticated, Request);
            helper.Method(async () => Mapper.ToApiUserProfile(await _userService.GetUserProfile(name)));
            return await helper.Result();
        }





        //todo: add /id to get controllers
        #endregion

        #region delete

        #endregion

        #region post

        #endregion
    }
}
