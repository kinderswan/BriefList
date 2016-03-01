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

        internal static BllSubItem ToBllSubItem(DalSubItem sub)
        {
            if (sub != null)
                return new BllSubItem
                {
                    Id = sub.Id,
                    Title = sub.Title,
                    Completed = sub.Completed,
                    BllItemId = sub.DalItemId
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
                    Title = item.Title
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
        internal static BllComments ToBllComments(DalComments coms)
        {
            if (coms != null)
                return new BllComments
                {
                    Comment = coms.Comment,
                    Id = coms.Id,
                    BllItemId = coms.DalItemId,
                    OwnerId = coms.OwnerId
                };
            return null;
        }

        internal static BllItemFile ToBllItemFile(DalItemFile file)
        {
            if (file != null)
                return new BllItemFile
                {
                    File = file.File,
                    Filename = file.Filename,
                    Id = file.Id,
                    BllItemId = file.DalItemId
                };
            return null;
        }
        #endregion

        #region 


        internal static DalComments ToDalComments(BllComments coms)
        {
            if (coms != null)
                return new DalComments
                {
                    Comment = coms.Comment,
                    DalItemId = coms.BllItemId,
                    Id = coms.Id,
                    OwnerId = coms.OwnerId
                };
            return null;
        }
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
                    Title = item.Title
                };
            return null;
        }
        internal static DalItemFile ToDalItemFile(BllItemFile file)
        {
            if (file != null)
                return new DalItemFile
                {
                    DalItemId = file.BllItemId,
                    File = file.File,
                    Filename = file.Filename,
                    Id = file.Id
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

        internal static DalSubItem ToDalSubItem(BllSubItem item)
        {
            if (item != null)
                return new DalSubItem
                {
                    Completed = item.Completed,
                    DalItemId = item.BllItemId,
                    Id = item.Id,
                    Title = item.Title
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
