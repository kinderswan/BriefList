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

        public async Task<ClaimsIdentity> Autorization(BllUserProfile blluserprofile)
        {
            ClaimsIdentity claim = null;
                var user = await _userRep.Get(blluserprofile.Name);
            if (user!=null && Crypto.VerifyHashedPassword(user.Password, blluserprofile.Password))
            {
                 claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, blluserprofile.Id.ToString(), ClaimValueTypes.String));
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, blluserprofile.Name,
                    ClaimValueTypes.String));
                claim.AddClaim(
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));
            }
            return claim;
        }

        public async Task<bool> UserNameExist(string name)
        {
            return await _userRep.UserNameExist(name);
        }

        public async Task<bool> UserEmailExist(string email)
        {
             return await _userRep.UserEmailExist(email);
        }

    }
}
