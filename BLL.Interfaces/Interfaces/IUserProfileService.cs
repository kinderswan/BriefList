using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserProfileService
    {
        void CreateUserProfile(BllUserProfile userProfile);

        Task<ClaimsIdentity> Autorization(BllUserProfile blluserprofile);
        Task<bool> UserNameExist(string name);
        Task<bool> UserEmailExist(string email);
    }
}
