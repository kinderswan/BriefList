using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider
{
    internal class BriefListSeed :/* DropCreateDatabaseAlways*/ DropCreateDatabaseIfModelChanges<EntityModelContext>
    {
        protected override void Seed(EntityModelContext context)
        {
            GetUserProfiles().ToList().ForEach(e=>context.OrmUserProfiles.Add(e));
            context.SaveChanges();
            GetLists().ToList().ForEach(e => context.OrmLists.Add(e));
            context.SaveChanges();
            GetItems().ToList().ForEach(e => context.OrmItems.Add(e));
            context.SaveChanges();
         //   GetSubItems().ToList().ForEach(e => context.OrmSubItems.Add(e));
        //    GetItemFiles().ToList().ForEach(e => context.OrmItemFiles.Add(e));
            GetComments().ToList().ForEach(e => context.OrmComments.Add(e));
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
                    Completed = true

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
        /*
        private static IEnumerable<OrmItemFile> GetItemFiles()
        {
            return new List<OrmItemFile>
            {
                new OrmItemFile
                {

                }
            };
        }

        private static IEnumerable<OrmSubItem> GetSubItems()
        {
            return new List<OrmSubItem>
            {
                new OrmSubItem
            {

            }

            };
        }

    */
        private static IEnumerable<OrmComments> GetComments()
        {
            return new List<OrmComments>
            {
                new OrmComments
                {
                    OrmItemId = 1,
                    Comment = "xexexex",
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
                    Description ="grown",
                    Title ="triks",
                    
                },
            };
        }


        private static IEnumerable<OrmUserProfile> GetUserProfiles()
        {
            return new List<OrmUserProfile>
            {
                new OrmUserProfile()
                {
                    TimeRegister = DateTime.Now,
                    Password ="000000",
                    Name = "vadim",
                    Email = "vadp@tut.by",
                    
                }
            };
        }
    }
}
