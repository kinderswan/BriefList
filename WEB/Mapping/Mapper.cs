using System;
using BLL.Interfaces.BLLModels;
using WEB.Models;

namespace WEB.Mapping
{
    public static class Mapper
    {
        public static BllUserProfile ToBllUserProfileLoginModel(LoginModel model)
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

        public static BllUserProfile ToBllUserProfileRegisterModel(RegisterModel model)
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
    }
}
