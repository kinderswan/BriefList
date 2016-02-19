using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.ORMModels;

namespace DAL
{
    internal class BriefListSeed : DropCreateDatabaseIfModelChanges<EntityModelContext>
    {
        protected override void Seed(EntityModelContext context)
        {
            GetUserProfiles().ToList().ForEach(e=>context.OrmUserProfiles.Add(e));
            context.SaveChanges();
            GetLists().ToList().ForEach(e => context.OrmLists.Add(e));
            context.SaveChanges();
            GetItems().ToList().ForEach(e => context.OrmItems.Add(e));
            context.SaveChanges();
            GetSubItems().ToList().ForEach(e => context.OrmSubItems.Add(e));
            GetItemFiles().ToList().ForEach(e => context.OrmItemFiles.Add(e));
            GetComments().ToList().ForEach(e => context.OrmComments.Add(e));
            context.SaveChanges();
        }

        private static IEnumerable<OrmComments> GetComments()
        {
            return new List<OrmComments>
            {
                new OrmComments
                {

                }
            };
        }

        private static IEnumerable<OrmItem> GetItems()
        {
            return new List<OrmItem>
            {

            };
        }

        private static IEnumerable<OrmItemFile> GetItemFiles()
        {
            return new List<OrmItemFile>
            {
            };
        }

        private static IEnumerable<OrmList> GetLists()
        {
            return new List<OrmList>
            {
                
            };
        }
        private static IEnumerable<OrmSubItem> GetSubItems()
        {
            return new List<OrmSubItem>
            {

            };
        }

        private static IEnumerable<OrmUserProfile> GetUserProfiles()
        {
            return new List<OrmUserProfile>
            {
                new OrmUserProfile()
                {
                    
                }
            };
        }
    }
}
