using System;
using BLL.Interfaces.BLLModels;
using WEB.Models;
using WEB.Models.ApiModels;

namespace WEB.Mapping
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
        internal static ApiItem ToApiItem(BllItem item)
        {
            if (item != null)
                return new ApiItem
                {
                    Id = item.Id,
                    BllListId = item.BllListId,
                    Title = item.Title,
                    Completed = item.Completed,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete
                };
            return null;
        }
        #endregion
    }
}
