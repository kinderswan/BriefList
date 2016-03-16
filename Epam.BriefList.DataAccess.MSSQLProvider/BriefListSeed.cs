using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Helpers;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider
{
    internal class BriefListSeed : DropCreateDatabaseIfModelChanges<EntityModelContext>
    {
        protected override void Seed(EntityModelContext context)
        {
            GetUserProfiles().ToList().ForEach(e => context.OrmUserProfiles.Add(e));
            context.SaveChanges();
            GetLists().ToList().ForEach(e => context.OrmLists.Add(e));
            context.SaveChanges();
            GetItems().ToList().ForEach(e => context.OrmItems.Add(e));
            context.SaveChanges();
        }

        private static IEnumerable<OrmItem> GetItems()
        {
            return new List<OrmItem>
            {
                new OrmItem
                {
                    Title = "hey",
                    Starred = true,
                    OrmListId = 1,
                    Completed = true

                },

                new OrmItem
                {
                    Title = "rrrt",
                    Starred = true,
                    OrmListId = 2,
                    Completed = true

                },

                new OrmItem
                {
                    Title = "tytyty",
                    Starred = false,
                    OrmListId = 1,
                    Completed = false

                },

                new OrmItem
                {
                    Title = "dynai",
                    Starred = true,
                    OrmListId = 2,
                    Completed = false

                }
            };
        }

      
        private static IEnumerable<OrmList> GetLists()
        {
            return new List<OrmList>
            {
                new OrmList
                {
                    OwnerId = 1,
                    Description = "tytty",
                    Title = "table",

                },
                new OrmList
                {
                    OwnerId = 1,
                    Description = "grown",
                    Title = "triks",

                },
            };
        }


        private static IEnumerable<OrmUserProfile> GetUserProfiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\fonts\\index.jpg";
            OrmUserProfile userProfile;
            using (FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Byte[] imageBytes = new byte[fStream.Length];
                fStream.Read(imageBytes, 0, imageBytes.Length);
                userProfile = new OrmUserProfile()
                {
                    Photo = imageBytes,
                    TimeRegister = DateTime.Now,
                    Password = Crypto.SHA1("000000"),
                    Name = "vadim",
                    Email = "vadp@tut.by",

                };
            }

            return new List<OrmUserProfile>
            {
                userProfile
            };
        }
    }
}
