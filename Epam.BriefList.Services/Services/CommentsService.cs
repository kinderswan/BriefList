using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.Services.API.Interfaces;

namespace Epam.BriefList.Services.Services
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
