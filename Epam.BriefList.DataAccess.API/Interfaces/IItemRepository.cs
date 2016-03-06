

using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.BriefList.DataAccess.API.Models;

namespace Epam.BriefList.DataAccess.API.Interfaces
{
    public interface IItemRepository : IRepository<DalItem>
    {
        Task<IEnumerable<DalItem>> GetByListId(int id,bool completed);
    }
}
