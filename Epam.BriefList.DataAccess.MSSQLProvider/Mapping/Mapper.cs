﻿using Epam.BriefList.DataAccess.API.Models;
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

        internal static OrmSubItem ToOrmSubItem(DalSubItem sub)
        {
            if (sub != null)
                return new OrmSubItem()
                { 
                    Id = sub.Id,
                    Title = sub.Title,
                    Completed = sub.Completed,
                    OrmItemId = sub.DalItemId
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
        internal static OrmComments ToOrmComments(DalComments coms)
        {
            if (coms != null)
                return new OrmComments
                {
                    Comment = coms.Comment,
                    Id = coms.Id,
                    OrmItemId = coms.DalItemId,
                    OwnerId = coms.OwnerId
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
                    Id = file.Id,
                    OrmItemId = file.DalItemId
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
                    DalItemId = coms.OrmItemId,
                    Id = coms.Id,
                    OwnerId = coms.OwnerId
                };
            return null;
        }
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
                    Title = item.Title
                };
            return null;
        }
        internal static DalItemFile ToDalItemFile(OrmItemFile file)
        {
            if (file != null)
                return new DalItemFile
                {
                    DalItemId = file.OrmItemId,
                    File = file.File,
                    Filename = file.Filename,
                    Id = file.Id
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

        internal static DalSubItem ToDalSubItem(OrmSubItem item)
        {
            if (item != null)
                return new DalSubItem
                {
                    Completed = item.Completed,
                    DalItemId = item.OrmItemId,
                    Id = item.Id,
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