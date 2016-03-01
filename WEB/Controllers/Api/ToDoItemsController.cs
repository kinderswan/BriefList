using System;
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
    public class ToDoItemsController : ApiController
    {
        private readonly IItemService _itemService;

        public ToDoItemsController() { }

        public ToDoItemsController(IItemService itemService)
        {
            _itemService = itemService;
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
        [Route("api/lists/{listId}/todoitems")]
        public async Task<IEnumerable<ApiItem>> GetListsTodoItems(int listId)
        {
            return (await _itemService.GetListToDoItems(listId)).Select(Mapper.ToApiItem);
        }
    }
}
