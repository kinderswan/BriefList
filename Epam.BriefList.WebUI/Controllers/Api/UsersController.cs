using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.HelperExtension;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userService;

        public UsersController() { }

        public UsersController(IUserProfileService userProfileService, IListService listService, IItemService itemService)
        {
            _userService = userProfileService;
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

        [HttpPut]
        [Route("api/updatePersonalUsers")]
        public void UpdatePersonalData([FromBody]ApiUserProfile model)
        {
            if (ModelState.IsValid)
            {
                 _userService.UpdatePersonalData(Mapper.ToBllUserProfile(model));
            }
            else ModelState.AddModelError("", "Неправильный ввод данных");
        }

        [HttpPut]
        [Route("api/updatePassword")]
        public async void UpdatePassword([FromBody]PasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //ПРИМЕНИТЬ!!
              var key = await _userService.UpdatePassword(Mapper.ToBllPassword(model));
            }
            else ModelState.AddModelError("","Неправильный ввод пароля");
        }

        [HttpPut]
        [Route("api/updatePhoto")]
        public void UpdatePhoto(byte[]/*??????????*/ photo)
        {
            _userService.UpdatePhoto(photo);
        }

        //todo: add /id to get controllers
        #endregion

        #region delete

        #endregion

        #region post

        #endregion
    }
}
