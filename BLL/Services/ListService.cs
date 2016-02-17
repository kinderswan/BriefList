using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ListService: IListService
    {
        private readonly IListRepository listRep;
        private readonly IUnitOfWork uow;

        public ListService(IListRepository listRep, IUnitOfWork uow)
        {
            this.listRep = listRep;
            this.uow = uow;
        }
    }
}
