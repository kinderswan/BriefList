using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class CommentsService: ICommentsService
    {
        private readonly ICommentsRepository _comRep;
        private readonly IUnitOfWork _uow;

        public CommentsService(ICommentsRepository comRep, IUnitOfWork uow)
        {
            _comRep = comRep;
            _uow = uow;
        }


    }
}
