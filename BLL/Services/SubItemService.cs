using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
   public class SubItemService: ISubItemService
    {
        private readonly ISubItemRepository _subitemRep;
        private readonly IUnitOfWork _uow;

        public SubItemService(ISubItemRepository subitemRep, IUnitOfWork uow)
        {
            _subitemRep = subitemRep;
            _uow = uow;
        }
    }
}
