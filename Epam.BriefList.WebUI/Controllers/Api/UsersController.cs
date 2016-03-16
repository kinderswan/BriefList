using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Classes;
using Epam.BriefList.WebUI.Filters;
using Epam.BriefList.WebUI.HelperExtension;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models;
using Epam.BriefList.WebUI.Models.ApiModels;
using Newtonsoft.Json;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userService;

        public UsersController() { }

        public UsersController(IUserProfileService userProfileService)
        {
            _userService = userProfileService;
        }


        #region get

        [HttpGet]
        [CustomException(ExceptionType = typeof(InvalidOperationException), StatusCode = HttpStatusCode.BadRequest, Message = "Id incorrect")]
        public async Task<IHttpActionResult> GetUser(int? id)
        {
            return Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(id.Value)));
        }

        /*[System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetUser(string name)
        {
            return  Json(Mapper.ToApiUserProfile(await _userService.GetUserProfile(name)));
        }*/

        [HttpPut]
        [Route("updatePersonalData")]
        public IHttpActionResult UpdatePersonalData([FromBody]ApiUserProfile model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userService.UpdatePersonalData(Mapper.ToBllUserProfile(model));
            return Json(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("updatePassword")]
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
        [Route("updatePhoto/{id}")]
        [CustomException(ExceptionType = typeof(InvalidOperationException), StatusCode = HttpStatusCode.BadRequest, Message = "Id incorrect")]
        [CustomException(ExceptionType = typeof(ArgumentOutOfRangeException), StatusCode = HttpStatusCode.BadRequest, Message = "ArgumentOutOfRangeException")]
        public IHttpActionResult UpdatePhoto(int? id)
        {
                var image = HttpContext.Current.Request.Files[0];
                _userService.UpdatePhoto(id.Value, Image.CreateBllImage(image));
                return  Json(StatusCode(HttpStatusCode.NoContent));
        }

        #endregion
    }
}
