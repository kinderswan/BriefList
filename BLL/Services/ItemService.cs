using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class ItemService: IItemService
    {
        private readonly IItemRepository itemRep;
        private readonly IUnitOfWork uow;

        public ItemService(IItemRepository itemRep, IUnitOfWork uow)
        {
            this.itemRep = itemRep;
            this.uow = uow;
        }
    }
}
