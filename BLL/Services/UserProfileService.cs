using BLL.Services.Interfaces;
using BLL.BLLModels;
using BLL.Mapping;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userRep;
        private readonly IUnitOfWork _uow;
        public UserProfileService(IUserProfileRepository userRep, IUnitOfWork uow)
        {
            _userRep = userRep;
            _uow = uow;
        }

        public void CreateUserProfile(BllUserProfile userProfile)
        {
            _userRep.Add(Mapper.ToDalUserProfile(userProfile));
        }
    }
}
