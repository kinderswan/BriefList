using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Classes;
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
        [Route("api/users/updatePersonalUsers")]
        public IHttpActionResult UpdatePersonalData([FromBody]ApiUserProfile model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userService.UpdatePersonalData(Mapper.ToBllUserProfile(model));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/users/updatePassword")]
        public async Task<IHttpActionResult> UpdatePassword([FromBody]PasswordModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userService.UpdatePassword(Mapper.ToBllPassword(model)))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.Forbidden);
        }

        [HttpPost]
        [Route("api/users/updatePhoto/{id}")]
        public IHttpActionResult UpdatePhoto(int id)
        {
            var image = HttpContext.Current.Request.Files[0];

            if (image != null)
            {
                _userService.UpdatePhoto(id, Image.CreateBllImage(image));
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest("Load File is null");
            }
        }
        #endregion
    }
}
