using DAL.Interfaces.DALModels;
using ORM.ORMModels;

namespace DAL.Mapping
{
    internal static class Mapper
    {
        #region Dal to ORM
        internal static OrmUserProfile ToOrmUserProfile(DalUserProfile profile)
        {
            if (profile != null)
                return new OrmUserProfile()
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

        internal static OrmSubItem ToOrmSubItem(DalSubItem sub)
        {
            if (sub != null)
                return new OrmSubItem()
                { 
                    ID = sub.ID,
                    Title = sub.Title,
                    Completed = sub.Completed,
                    OrmItemID = sub.DalItemID
                };
            return null;
        }
        internal static OrmItem ToOrmItem(DalItem item)
        {
            if (item != null)
                return new OrmItem()
                {
                    Completed = item.Completed,
                    ID = item.ID,
                    OrmListID = item.DalListID,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                };
            return null;
        }

        internal static OrmList ToOrmList(DalList list)
        {
            if (list != null)
                return new OrmList
                {
                    ID = list.ID,
                    Description = list.Description,
                    OwnerID = list.OwnerID,
                    Title = list.Title
                };
            return null;
        }
        internal static OrmComments ToOrmComments(DalComments coms)
        {
            if (coms != null)
                return new OrmComments
                {
                    Comment = coms.Comment,
                    ID = coms.ID,
                    OrmItemID = coms.DalItemID,
                    OwnerID = coms.OwnerID
                };
            return null;
        }

        internal static OrmItemFile ToOrmItemFile(DalItemFile file)
        {
            if (file != null)
                return new OrmItemFile
                {
                    File = file.File,
                    Filename = file.Filename,
                    ID = file.ID,
                    OrmItemID = file.DalItemID
                };
            return null;
        }
        #endregion

        #region Orm to Dal


        internal static DalComments ToDalComments(OrmComments coms)
        {
            if (coms != null)
                return new DalComments
                {
                    Comment = coms.Comment,
                    DalItemID = coms.OrmItemID,
                    ID = coms.ID,
                    OwnerID = coms.OwnerID
                };
            return null;
        }
        internal static DalItem ToDalItem(OrmItem item)
        {
            if (item != null)
                return new DalItem
                {
                    Completed = item.Completed,
                    DalListID = item.OrmListID,
                    ID = item.ID,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title
                };
            return null;
        }
        internal static DalItemFile ToDalItemFile(OrmItemFile file)
        {
            if (file != null)
                return new DalItemFile
                {
                    DalItemID = file.OrmItemID,
                    File = file.File,
                    Filename = file.Filename,
                    ID = file.ID
                };
            return null;
        }
        internal static DalList ToDalList(OrmList list)
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

        internal static DalSubItem ToDalSubItem(OrmSubItem item)
        {
            if (item != null)
                return new DalSubItem
                {
                    Completed = item.Completed,
                    DalItemID = item.OrmItemID,
                    ID = item.ID,
                    Title = item.Title
                };
            return null;
        }

        internal static DalUserProfile ToDalUserProfile(OrmUserProfile user)
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
