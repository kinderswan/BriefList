using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.HelperExtension;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    [Authorize]
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
        public  async Task<IHttpActionResult> GetUser(int id)
        {
            return Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(id)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUser(string name)
        {
            return Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(name)));
        }





        //todo: add /id to get controllers
        #endregion

        #region delete

        #endregion

        #region post

        #endregion
    }
}
