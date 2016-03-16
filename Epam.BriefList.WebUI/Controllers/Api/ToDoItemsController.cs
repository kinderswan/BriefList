using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
{
    public class ToDoItemsController : ApiController
    {
        private readonly IItemService _itemService;

        public ToDoItemsController() { }

        public ToDoItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("api/todoitems/{id}")]
        public async Task<ApiItem> GetToDoItems(int id)
        {
            return Mapper.ToApiItem(await _itemService.GetToDoItem(id));
        }
        [HttpGet]
        [Route("api/users/{userId}/todoitems")]
        public async Task<IEnumerable<ApiItem>> GetUserToDoItems(int userId)
        {
            return (await _itemService.GetUserToDoItems(userId)).Select(Mapper.ToApiItem);
        }

        [HttpGet]
        [Route("api/users/{userId}/todoitems/{id}")]
        public async Task<ApiItem> GetUserToDoItem(int userId, int id)
        {
            return Mapper.ToApiItem((await _itemService.GetUserToDoItems(userId)).FirstOrDefault(t => t.Id == id));
        }

        [HttpGet]
        [Route("api/users/{userId}/lists/{listId}/todoitems")]
        public async Task<IEnumerable<ApiItem>> GetUserListTodoItems(int userId, int listId)
        {
            return (await _itemService.GetUserListToDoItems(userId, listId)).Select(Mapper.ToApiItem);
        }

        [HttpGet]
        [Route("api/users/{userId}/lists/{listId}/todoitems/{id}")]
        public async Task<ApiItem> GetUserListTodoItem(int userId, int listId, int id)
        {
            return Mapper.ToApiItem((await _itemService.GetUserListToDoItems(userId, listId)).FirstOrDefault(t => t.Id == id));
        }
        
        [HttpGet]
        [Route("api/lists/{listId}/todoitems/{completed}")]
        public async Task<IHttpActionResult> GetListsTodoItems(int listId,bool completed)
        {
            return Json((await _itemService.GetListToDoItems(listId, completed)).Select(Mapper.ToApiItem));
        }

        [HttpPost]
        [Route("api/todoitems")]
        public void AddItems([FromBody]ApiItem model)
        {
           _itemService.AddItem(Mapper.ToBllItem(model));
        }

        [HttpDelete]
        [Route("api/todoitems/delete/{id}")]
        public void DeleteItems(int id)
        {
            _itemService.Delete(id);
        }

        [HttpPut]
        [Route("api/todoitems/update")]
        public void UpdateItems([FromBody]ApiItem model)
        {
            _itemService.UpdateItem(Mapper.ToBllItem(model));
        }
    }
}
