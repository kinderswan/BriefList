using BLL.Interfaces.BLLModels;
using BLL.Interfaces.Interfaces;
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
