using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.Services.API.Interfaces;

namespace Epam.BriefList.Services.Services
{
   public class ItemFileService: IItemFileService
    {
        private readonly IItemFileRepository _itemFileRep;
        private readonly IUnitOfWork _uow;

        public ItemFileService(IItemFileRepository itemFileRep, IUnitOfWork uow)
        {
            _itemFileRep = itemFileRep;
            _uow = uow;
        }
    }
}
