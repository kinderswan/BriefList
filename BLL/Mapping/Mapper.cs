using BLL.Interfaces.BLLModels;
using DAL.Interfaces.DALModels;

namespace BLL.Mapping
{
    public static class Mapper
    {
        #region 
        public static BllUserProfile ToBllUserProfile(DalUserProfile profile)
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

        public static BllSubItem ToBllSubItem(DalSubItem sub)
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
        public static BllItem ToBllItem(DalItem item)
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

        public static BllList ToBllList(DalList list)
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
        public static BllComments ToBllComments(DalComments coms)
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

        public static BllItemFile ToBllItemFile(DalItemFile file)
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


        public static DalComments ToDalComments(BllComments coms)
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
        public static DalItem ToDalItem(BllItem item)
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
        public static DalItemFile ToDalItemFile(BllItemFile file)
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
        public static DalList ToDalList(BllList list)
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
        public static DalSubItem ToDalSubItem(BllSubItem item)
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
        public static DalUserProfile ToDalUserProfile(BllUserProfile user)
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
