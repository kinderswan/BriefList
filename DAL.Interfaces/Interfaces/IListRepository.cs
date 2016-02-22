
using System.Collections.Generic;
using DAL.Interfaces.DALModels;

namespace DAL.Interfaces.Interfaces
{
    public interface IListRepository : IRepository<DalList>
    {
        IEnumerable<DalList> GetAllListsNames();
    }
}
