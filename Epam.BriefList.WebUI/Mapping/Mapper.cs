using System;
using Epam.BriefList.Services.API.Models;
using Epam.BriefList.WebUI.Models;
using Epam.BriefList.WebUI.Models.ApiModels;

namespace Epam.BriefList.WebUI.Mapping
{
    internal static class Mapper
    {
        internal static BllUserProfile ToBllUserProfileLoginModel(LoginModel model)
        {
            if (model != null)
                return new BllUserProfile
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password
                };
            return null;
        }

        internal static BllUserProfile ToBllUserProfileRegisterModel(RegisterModel model)
        {
            if (model != null)
                return new BllUserProfile
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    Photo = model.Photo,
                    TimeRegister = DateTime.Now
                };
            return null;
        }

        internal static ListModel ToListModel(BllList model)
        {
            if (model != null)
                return new ListModel
                {
                    Id = model.Id,
                    Description = model.Description,
                    Title = model.Title,
                    //не так!это не надо!!!
                    // OwnerId = model.OwnerId,

                };
            return null;
        }

        #region ApiMapping


        internal static ApiUserProfile ToApiUserProfile(BllUserProfile user)
        {
            if (user != null)
                return new ApiUserProfile
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    Password = user.Password,
                    Photo = user.Photo,
                    TimeRegister = user.TimeRegister
                };
            return null;
        }

        internal static ApiList ToApiList(BllList list)
        {
            if (list != null)
                return new ApiList
                {
                    Id = list.Id,
                    Description = list.Description,
                    OwnerId = list.OwnerId,
                    Title = list.Title
                };
            return null;
        }

        internal static BllList ToBllList(ApiList list)
        {
            if (list != null)
                return new BllList
                {
                    Id = list.Id,
                    Description = list.Description,
                    OwnerId = list.OwnerId,
                    Title = list.Title
                };
            return null;
        }

        internal static ApiItem ToApiItem(BllItem item)
        {
            if (item != null)
                return new ApiItem
                {
                    Id = item.Id,
                    ListId = item.BllListId,
                    Title = item.Title,
                    Completed = item.Completed,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete
                };
            return null;
        }

        internal static BllItem ToBllItem(ApiItem item)
        {
            if (item != null)
                return new BllItem
                {
                    Id = item.Id,
                    BllListId = item.ListId,
                    Title = item.Title,
                    Completed = item.Completed,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete
                };
            return null;
        }


        #endregion

        internal static BllUserProfile ToBllUserProfile(ApiUserProfile model)
        {
            if (model != null)
                return new BllUserProfile
                {
                    TimeRegister = model.TimeRegister,
                    Photo = model.Photo,
                    Id = model.Id,
                    Password = model.Password,
                    Email = model.Email,
                    Name = model.Name
                };
            return null;
        }
        
        internal static BllPassword ToBllPassword(PasswordModel model)
        {
            if (model != null)
                return new BllPassword
                {
                    Id = model.Id,
                    NewPassword = model.NewPassword,
                    OldPassword = model.OldPassword,
                };
            return null;
        }
    }
}
