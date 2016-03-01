using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
    public interface IListService
    {
        IEnumerable<BllList> GetAllListsNames();
        Task<IEnumerable<BllList>> GetAllLists();
        Task<IEnumerable<BllList>> GetUserLists(int id);
    }
}
