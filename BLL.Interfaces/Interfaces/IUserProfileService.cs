using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces.BLLModels;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserProfileService
    {
        void CreateUserProfile(BllUserProfile userProfile);
        void DeleteUserProfile(int id);
        Task<IEnumerable<BllUserProfile>> GetUserProfiles();
        Task<BllUserProfile> GetUserProfile(int id);
        Task<BllUserProfile> GetUserProfile(string name);
        Task<ClaimsIdentity> Autorization(BllUserProfile blluserprofile);
        Task<bool> UserNameExist(string name);
        Task<bool> UserEmailExist(string email);
    }
}
