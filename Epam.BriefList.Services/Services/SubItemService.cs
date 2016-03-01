using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.Services.API.Interfaces;

namespace Epam.BriefList.Services.Services
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
