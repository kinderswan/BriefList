using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class SubItemService: ISubItemService
    {
        private readonly ISubItemRepository subitemRep;
        private readonly IUnitOfWork uow;

        public SubItemService(ISubItemRepository subitemRep, IUnitOfWork uow)
        {
            this.subitemRep = subitemRep;
            this.uow = uow;
        }
    }
}
