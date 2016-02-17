using BLL.Interfaces.BLLModels;
using DAL.Interfaces.DALModels;

namespace BLL.Mapping
{
    internal static class Mapper
    {
        #region 
        internal static BllUserProfile ToBllUserProfile(DalUserProfile profile)
        {
            if (profile != null)
                return new BllUserProfile()
                {
                    Email = profile.Email,
                    ID = profile.ID,
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
                return new BllSubItem()
                {
                    ID = sub.ID,
                    Title = sub.Title,
                    Completed = sub.Completed,
                    BllItemID = sub.DalItemID
                };
            return null;
        }
        internal static BllItem ToBllItem(DalItem item)
        {
            if (item != null)
                return new BllItem()
                {
                    Completed = item.Completed,
                    ID = item.ID,
                    BllListID = item.DalListID,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                };
            return null;
        }
        internal static BllList ToBllList(DalList list)
        {
            if (list != null)
                return new BllList
                {
                    ID = list.ID,
                    Description = list.Description,
                    OwnerID = list.OwnerID,
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
                    ID = coms.ID,
                    BllItemID = coms.DalItemID,
                    OwnerID = coms.OwnerID
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
                    ID = file.ID,
                    BllItemID = file.DalItemID
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
                    DalItemID = coms.BllItemID,
                    ID = coms.ID,
                    OwnerID = coms.OwnerID
                };
            return null;
        }
        internal static DalItem ToDalItem(BllItem item)
        {
            if (item != null)
                return new DalItem
                {
                    Completed = item.Completed,
                    DalListID = item.BllListID,
                    ID = item.ID,
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
                    DalItemID = file.BllItemID,
                    File = file.File,
                    Filename = file.Filename,
                    ID = file.ID
                };
            return null;
        }

        internal static DalList ToDalList(BllList list)
        {
            if (list != null)
                return new DalList
                {
                    Description = list.Description,
                    ID = list.ID,
                    OwnerID = list.OwnerID,
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
                    DalItemID = item.BllItemID,
                    ID = item.ID,
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
                    ID = user.ID,
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
