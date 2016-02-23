using System.Collections.Generic;
using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
   public interface IListService
    {
       IEnumerable<BllList> GetAllListsNames();
    }
}
