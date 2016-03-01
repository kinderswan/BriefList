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
        public async Task<IEnumerable<BllList>> GetUserLists(int id)
        {
            return (await _listRep.GetAll()).Where(t => t.OwnerId == id).Select(Mapper.ToBllList);
        }
    }
}
