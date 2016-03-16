using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Classes;
using Epam.BriefList.WebUI.HelperExtension;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    [System.Web.Http.Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userService;

        public UsersController() { }

        public UsersController(IUserProfileService userProfileService)
        {
            _userService = userProfileService;
        }


        #region get
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetUsers()
        {
            var helper = new HttpResponseGetHelper<IEnumerable<ApiUserProfile>>(User.Identity.IsAuthenticated, Request);
            helper.Method( async ()=> (await _userService.GetUserProfiles()).Select(Mapper.ToApiUserProfile));
            return await helper.Result();
        }

        [System.Web.Http.HttpGet]
        public  async Task<IHttpActionResult> GetUser(int id)
        {
            return Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(id)));
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetUser(string name)
        {
            return /*Json(Request.CreateResponse(HttpStatusCode.OK, Mapper.ToApiUserProfile(await _userService.GetUserProfile(name))));*/ Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(name)));
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/users/updatePersonalUsers")]
        public IHttpActionResult UpdatePersonalData([FromBody]ApiUserProfile model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userService.UpdatePersonalData(Mapper.ToBllUserProfile(model));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/users/updatePassword")]
        public async Task<IHttpActionResult> UpdatePassword([FromBody]PasswordModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userService.UpdatePassword(Mapper.ToBllPassword(model)))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.Forbidden);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/users/updatePhoto/{id}")]
        public JsonResult<HttpResponseMessage> UpdatePhoto(int id)
        {
            try
            {
                var image = HttpContext.Current.Request.Files[0];
                _userService.UpdatePhoto(id, Image.CreateBllImage(image));
                return Json(new HttpResponseMessage(HttpStatusCode.NoContent)); // Json(StatusCode(HttpStatusCode.NoContent));
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                return Json(Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex));
                    // Json(new HttpResponseMessage(HttpStatusCode.BadRequest)); //BadRequest("System.ArgumentOutOfRangeException");
            }

        }

        #endregion
    }
}
