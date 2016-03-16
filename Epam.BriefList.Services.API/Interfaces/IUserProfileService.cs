using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Epam.BriefList.Services.API.Models;

namespace Epam.BriefList.Services.API.Interfaces
{
    public interface IUserProfileService
    {
        void CreateUserProfile(BllUserProfile userProfile);
        void DeleteUserProfile(int id);
        Task<BllUserProfile> GetUserProfile(int id);
        Task<BllUserProfile> GetUserProfile(string name);
        Task<ClaimsIdentity> Autorization(BllUserProfile blluserprofile);
        Task<bool> UserNameExist(string name);
        Task<bool> UserEmailExist(string email);
        Task<bool> UpdatePassword(BllPassword model);
        void UpdatePersonalData(BllUserProfile blluserprofile);
        void UpdatePhoto(int id, byte[] photo);
    }
}
