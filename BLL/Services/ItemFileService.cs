using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class ItemFileService: IItemFileService
    {
        private readonly IItemFileRepository itemFileRep;
        private readonly IUnitOfWork uow;

        public ItemFileService(IItemFileRepository itemFileRep, IUnitOfWork uow)
        {
            this.itemFileRep = itemFileRep;
            this.uow = uow;
        }
    }
}
