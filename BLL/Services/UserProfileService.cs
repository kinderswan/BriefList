using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
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
            _uow.Commit();
        }

        public void DeleteUserProfile(int id)
        {
            _userRep.Delete(id);
            _uow.Commit();
        }
        public async Task<IEnumerable<BllUserProfile>> GetUserProfiles() => (await _userRep.GetAll()).Select(Mapper.ToBllUserProfile);

        public async Task<BllUserProfile> GetUserProfile(int id)
        {
            return Mapper.ToBllUserProfile(await _userRep.Get(id));
        }

        public async Task<BllUserProfile> GetUserProfile(string name)
        {
            return Mapper.ToBllUserProfile(await _userRep.Get(name));
        }

        public async Task<ClaimsIdentity> Autorization(BllUserProfile blluserprofile)
        {
            ClaimsIdentity claim = null;
                var user = await _userRep.Get(blluserprofile.Name);
            if (user!=null && Crypto.VerifyHashedPassword(Crypto.HashPassword(user.Password), blluserprofile.Password))
            {
                claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);
                claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name,ClaimValueTypes.String));
                claim.AddClaim(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String));
                claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider","OWIN Provider", ClaimValueTypes.String));
            }
            return claim;
        }

        public async Task<bool> UserNameExist(string name)=>await _userRep.UserNameExist(name);

        public async Task<bool> UserEmailExist(string email)=>await _userRep.UserEmailExist(email);

        

    }
}
