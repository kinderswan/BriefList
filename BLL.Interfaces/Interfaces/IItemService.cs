using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<BllItem>> GetToDoItems();
        Task<IEnumerable<BllItem>> GetUserToDoItems(int id);
        Task<IEnumerable<BllItem>> GetUserListToDoItems(int userId, int listId);
    }
}
