using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
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
    }
}
