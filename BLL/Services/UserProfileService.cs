using BLL.Mapping;
using DAL.Interfaces.Interfaces;
using BLL.Interfaces.Interfaces;
using BLL.Interfaces.BLLModels;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository userRep;
        private readonly IUnitOfWork uow;

        public UserProfileService(IUserProfileRepository userRep, IUnitOfWork uow)
        {
            this.userRep = userRep;
            this.uow = uow;
        }

        public void CreateUserProfile(BllUserProfile userProfile)
        {
            userRep.Add(Mapper.ToDalUserProfile(userProfile));
        }
    }
}
