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
    public class ListService: IListService
    {
        private readonly IListRepository _listRep;
        private readonly IUnitOfWork _uow;

        public ListService(IListRepository listRep, IUnitOfWork uow)
        {
            _listRep = listRep;
            _uow = uow;
        }

        public IEnumerable<BllList> GetAllListsNames() => _listRep.GetAllListsNames().Select(Mapper.ToBllList);
        public async Task<IEnumerable<BllList>> GetAllLists() => (await _listRep.GetAll()).Select(Mapper.ToBllList);
        public async Task<IEnumerable<BllList>> GetUserLists(int id) => (await _listRep.GetByOwnerId(id)).Select(Mapper.ToBllList);

        public void AddList(BllList list)
        {
            _listRep.Add(Mapper.ToDalList(list));
            _uow.Commit();
        }

        public async void Delete(int id)
        {
            if (await _listRep.Get(id) == null) return;
            _listRep.Delete(id);
            _uow.Commit();
        }
        public void UpdateList(BllList bllList)
        {
            _listRep.Update(Mapper.ToDalList(bllList));
            _uow.Commit();
        }
    }
}
