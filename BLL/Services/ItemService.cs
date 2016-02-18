using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
   public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRep;
        private readonly IUnitOfWork _uow;

        public ItemService(IItemRepository itemRep, IUnitOfWork uow)
        {
            _itemRep = itemRep;
            _uow = uow;
        }
    }
}
