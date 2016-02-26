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

        
        [HttpGet]
        [Route("api/users/{userId}/lists/{id}")]
        public async Task<ApiList> GetUserList(int userId, int id)
        {
            return Mapper.ToApiList((await _listService.GetUserLists(userId)).FirstOrDefault(t => t.Id == id));
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
