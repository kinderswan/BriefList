using Epam.BriefList.DataAccess.API.Models;
using Epam.BriefList.Services.API.Models;

namespace Epam.BriefList.Services.Mapping
{
    internal static class Mapper
    {
        #region 
        internal static BllUserProfile ToBllUserProfile(DalUserProfile profile)
        {
            if (profile != null)
                return new BllUserProfile
                {
                    Email = profile.Email,
                    Id = profile.Id,
                    Name = profile.Name,
                    Password = profile.Password,
                    Photo = profile.Photo,
                    TimeRegister = profile.TimeRegister
                };
            return null;
        }

        
        internal static BllItem ToBllItem(DalItem item)
        {
            if (item != null)
                return new BllItem
                {
                    Completed = item.Completed,
                    Id = item.Id,
                    BllListId = item.DalListId,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                    Comment = item.Comment
                };
            return null;
        }
        internal static BllList ToBllList(DalList list)
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
     
        #endregion

        #region 


       
        internal static DalItem ToDalItem(BllItem item)
        {
            if (item != null)
                return new DalItem
                {
                    Completed = item.Completed,
                    DalListId = item.BllListId,
                    Id = item.Id,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                    Comment = item.Comment
                };
            return null;
        }
     

        internal static DalList ToDalList(BllList list)
        {
            if (list != null)
                return new DalList
                {
                    Description = list.Description,
                    Id = list.Id,
                    OwnerId = list.OwnerId,
                    Title = list.Title
                };
            return null;
        }
     
        internal static DalUserProfile ToDalUserProfile(BllUserProfile user)
        {
            if (user != null)
                return new DalUserProfile
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
        #endregion

    }
}
