using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.BriefList.Services.API.Models;

namespace Epam.BriefList.Services.API.Interfaces
{
    public interface IListService
    {
        IEnumerable<BllList> GetAllListsNames();
        Task<IEnumerable<BllList>> GetAllLists();
        Task<IEnumerable<BllList>> GetUserLists(int id);
        void AddList(BllList list);
        void Delete(int id);
        void UpdateList(BllList bllList);
    }
}
