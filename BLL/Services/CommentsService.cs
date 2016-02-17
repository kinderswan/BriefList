using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces.Interfaces;
using BLL.Interfaces.Interfaces;

namespace BLL.Services
{
    class CommentsService: ICommentsService
    {
        private readonly ICommentsRepository comRep;
        private readonly IUnitOfWork uow;

        public CommentsService(ICommentsRepository comRep, IUnitOfWork uow)
        {
            this.comRep = comRep;
            this.uow = uow;
        }


    }
}
