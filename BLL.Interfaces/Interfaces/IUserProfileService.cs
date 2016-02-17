using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserProfileService
    {
        void CreateUserProfile(BllUserProfile userProfile);
    }
}
