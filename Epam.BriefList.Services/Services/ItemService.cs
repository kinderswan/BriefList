using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.Services.API.Models;
using Epam.BriefList.Services.Mapping;

namespace Epam.BriefList.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRep;
        private readonly IListRepository _listRep;
        private readonly IUnitOfWork _uow;

        public ItemService(IItemRepository itemRep, IListRepository listRep, IUnitOfWork uow)
        {
            _itemRep = itemRep;
            _listRep = listRep;
            _uow = uow;
        }

        public async Task<IEnumerable<BllItem>> GetToDoItems() => (await _itemRep.GetAll()).Select(Mapper.ToBllItem);

        public async Task<IEnumerable<BllItem>> GetUserToDoItems(int id)
        {
            var listIds = (await _listRep.GetAll()).Where(t => t.OwnerId == id).Select(t => t.Id);
            var bllItems = new List<BllItem>();
            foreach (var item in listIds)
            {
                //незнание порождает демонов сознания
                bllItems.AddRange((await _itemRep.GetAll()).Where(t => t.DalListId == item).Select(Mapper.ToBllItem));
            }
            return bllItems;
        }

        public async Task<IEnumerable<BllItem>> GetUserListToDoItems(int userId, int listId)
        {
            var listIds = (await _listRep.GetAll()).Where(t => t.OwnerId == userId).Select(Mapper.ToBllList);
            if (listIds.Any(t => t.Id == listId))
            {
                return (await _itemRep.GetAll()).Where(t => t.DalListId == listId).Select(Mapper.ToBllItem);
            }
            return new List<BllItem>();
        }

        public async Task<IEnumerable<BllItem>> GetListToDoItems(int listId,bool completed) => (await _itemRep.GetByListId(listId,completed)).Select(Mapper.ToBllItem);

        public void AddItem(BllItem bllItem) => _itemRep.Add(Mapper.ToDalItem(bllItem));
        
    }
}
