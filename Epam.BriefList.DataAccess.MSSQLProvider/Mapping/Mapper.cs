using Epam.BriefList.DataAccess.API.Models;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Mapping
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
                    Id = profile.Id,
                    Name = profile.Name,
                    Password = profile.Password,
                    Photo = profile.Photo,
                    TimeRegister = profile.TimeRegister
                };
            return null;
        }

      
        internal static OrmItem ToOrmItem(DalItem item)
        {
            if (item != null)
                return new OrmItem()
                {
                    Completed = item.Completed,
                    Id = item.Id,
                    OrmListId = item.DalListId,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                    Comment = item.Comment
                };
            return null;
        }

        internal static OrmList ToOrmList(DalList list)
        {
            if (list != null)
                return new OrmList
                {
                    Id = list.Id,
                    Description = list.Description,
                    OwnerId = list.OwnerId,
                    Title = list.Title
                };
            return null;
        }
        

       
        #endregion

        #region Orm to Dal


       
        internal static DalItem ToDalItem(OrmItem item)
        {
            if (item != null)
                return new DalItem
                {
                    Completed = item.Completed,
                    DalListId = item.OrmListId,
                    Id = item.Id,
                    Starred = item.Starred,
                    TimeComplete = item.TimeComplete,
                    Title = item.Title,
                    Comment = item.Comment
                };
            return null;
        }
       
        internal static DalList ToDalList(OrmList list)
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

       
        internal static DalUserProfile ToDalUserProfile(OrmUserProfile user)
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
