using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Epam.BriefList.DataAccess.API.Models;
using Epam.BriefList.DataAccess.MSSQLProvider;
using Epam.BriefList.DataAccess.MSSQLProvider.Repository;
using Epam.BriefList.Orm.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Epam.BriefList.Tests
{
    [TestClass]
    public class BriefListTest
    {
        [TestMethod]
        public void UserRepository_AddItem_IsNotNullWhenGet()
        {
            var dbData = new DalUserProfile
            {
                Id = 100,
                Email = "mail1",
                Name = "name1",
                Password = "password1"
            };
            var dbSetMock = new Mock<DbSet<OrmUserProfile>>();
            var dbContextMock = new Mock<EntityModelContext>();
            dbContextMock.Setup(x => x.Set<OrmUserProfile>()).Returns(dbSetMock.Object);

            var repo = new UserProfileRepository(dbContextMock.Object);
            repo.Add(dbData);
            Assert.IsNotNull(repo.Get(100));
        }
        [TestMethod]
        public void ListRepository_Add_IsNotNullWhenGet()
        {
            var dbData = new DalList
            {
                Id = 100,
                Description = "aaa",
                Title = "aaa"
            };
            var dbSetMock = new Mock<DbSet<OrmList>>();
            var dbContextMock = new Mock<EntityModelContext>();
            dbContextMock.Setup(x => x.Set<OrmList>()).Returns(dbSetMock.Object);

            var repo = new ListRepository(dbContextMock.Object);
            repo.Add(dbData);
            Assert.IsNotNull(repo.Get(100));
        }
        [TestMethod]
        public void ItemRepository_Add_IsNotNullWhenGet()
        {
            var dbData = new DalItem()
            {
                Id = 100,
                Comment = "adfaf",
                Completed = true,
                Title = "sfsdf"
            };
            var dbSetMock = new Mock<DbSet<OrmItem>>();
            var dbContextMock = new Mock<EntityModelContext>();
            dbContextMock.Setup(x => x.Set<OrmItem>()).Returns(dbSetMock.Object);

            var repo = new ItemRepository(dbContextMock.Object);
            repo.Add(dbData);
            Assert.IsNotNull(repo.Get(100));
        }
    }
}
