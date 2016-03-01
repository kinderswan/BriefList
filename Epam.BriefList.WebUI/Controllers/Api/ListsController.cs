using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Controllers.Api
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

        [HttpGet]
        [Route("api/users/{userId}/lists/{id}")]
        public async Task<ApiList> GetUserList(int userId, int id)
        {
            return Mapper.ToApiList((await _listService.GetUserLists(userId)).FirstOrDefault(t => t.Id == id));
        }

    }
}