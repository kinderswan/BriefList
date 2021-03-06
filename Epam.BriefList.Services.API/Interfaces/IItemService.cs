﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.BriefList.Services.API.Models;

namespace Epam.BriefList.Services.API.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<BllItem>> GetToDoItems();
        Task<IEnumerable<BllItem>> GetUserToDoItems(int id);
        Task<IEnumerable<BllItem>> GetListToDoItems(int listId, bool completed);
        Task<IEnumerable<BllItem>> GetUserListToDoItems(int userId, int listId);
        Task<BllItem> GetToDoItem(int id);
        void AddItem(BllItem bllItem);
        void Delete(int id);
        void UpdateItem(BllItem bllItem);
    }
}
