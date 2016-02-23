using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
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
