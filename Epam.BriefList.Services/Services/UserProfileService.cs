using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.Services.API.Models;
using Epam.BriefList.Services.Mapping;

namespace Epam.BriefList.Services.Services
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

        private ClaimsPrincipal Identity => (ClaimsPrincipal)Thread.CurrentPrincipal;

        public void CreateUserProfile(BllUserProfile userProfile)
        {
            userProfile.Password = Crypto.HashPassword(userProfile.Password);
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
                var user = await _userRep.Get(blluserprofile.Email);
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

        public async void UpdatePersonalData(BllUserProfile model)
        {
            var user = await _userRep.Get(model.Id);
            user.Name = model.Name;
            user.Email = model.Email;
            _userRep.Update(user);
            _uow.Commit();
            ((ClaimsIdentity)Identity.Identity).RemoveClaim(((ClaimsIdentity)Identity.Identity).FindFirst(ClaimTypes.Name));
            ((ClaimsIdentity)Identity.Identity).RemoveClaim(((ClaimsIdentity)Identity.Identity).FindFirst(ClaimTypes.Email));
            ((ClaimsIdentity)Identity.Identity).AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ((ClaimsIdentity)Identity.Identity).AddClaim(new Claim(ClaimTypes.Name, user.Email));
        }

        public async Task<bool> UpdatePassword(BllPassword model)
        {
            var user = await _userRep.Get(model.Id);
            if (Crypto.VerifyHashedPassword(Crypto.HashPassword(user.Password), model.OldPassword))
            {
                user.Password = Crypto.HashPassword(model.NewPassword);
             _userRep.Update(user);
            _uow.Commit();
                return true;
            }
            return false;

        }

        public void UpdatePhoto(byte[] photo)
        {
            throw new NotImplementedException();
        }


    }
}
