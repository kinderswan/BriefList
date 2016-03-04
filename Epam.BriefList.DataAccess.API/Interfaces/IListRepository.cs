using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.BriefList.DataAccess.API.Models;

namespace Epam.BriefList.DataAccess.API.Interfaces
{
    public interface IListRepository : IRepository<DalList>
    {
        IEnumerable<DalList> GetAllListsNames();
        Task<IEnumerable<DalList>> GetByOwnerId(int id);
    }
}
