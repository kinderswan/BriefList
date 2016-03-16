using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Filters;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    public class ListsController : ApiController
    {
        private readonly IListService _listService;

        public ListsController() { }

        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        [Route("api/users/{userId}/lists")]
        [CustomException(ExceptionType = typeof(InvalidOperationException), StatusCode = HttpStatusCode.BadRequest, Message = "Id incorrect")]
        public async Task<IHttpActionResult> GetUserLists(int? userId)
        {
            return Json((await _listService.GetUserLists(userId.Value)).Select(Mapper.ToApiList));
        }

        [HttpGet]
        [Route("api/users/{userId}/lists/{id}")]
        public async Task<IHttpActionResult> GetUserList(int userId, int id)
        {
            return Json(Mapper.ToApiList((await _listService.GetUserLists(userId)).FirstOrDefault(t => t.Id == id)));
        }

        [HttpPost]
        [Route("api/lists/add")]
        public void AddList([FromBody]ApiList model)
        {
            _listService.AddList(Mapper.ToBllList(model));
        }

        [HttpDelete]
        [Route("api/lists/delete/{id}")]
        public void DeleteLists(int id)
        {
            _listService.Delete(id);
        }
        [HttpPut]
        [Route("api/lists/update")]
        public void UpdateList([FromBody]ApiList model)
        {
            _listService.UpdateList(Mapper.ToBllList(model));
        }
    }
}