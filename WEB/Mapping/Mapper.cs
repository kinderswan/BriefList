using System;
using BLL.Interfaces.BLLModels;
using WEB.Models;

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
    }
}
