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
    public class ListsController : ApiController
    {
        private readonly IUserProfileService _userService;
        private readonly IListService _listService;
        private readonly IItemService _itemService;

        public ListsController() { }

        public ListsController(IUserProfileService userProfileService, IListService listService, IItemService itemService)
        {
            _userService = userProfileService;
            _listService = listService;
            _itemService = itemService;
        }

        [HttpGet]
        [Route("api/users/{userId}/lists")]
        public async Task<IEnumerable<ApiList>> GetUserLists(int userId)
        {
            return (await _listService.GetUserLists(userId)).Select(Mapper.ToApiList);
        }

    }
}