using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBaseDataService.Implementation;
using Microsoft.Practices.ServiceLocation;
using BlogBaseDataService.Interfaces;
using BlogDatalayer;
using System.Linq;
using Microsoft.Practices.Unity;
using BlogBaseDatalayer.Interfaces;
using System.Data.Entity;


namespace BlogTests.DataServiceTests
{
    [TestClass]
    public class RepositoryTests : TestBase
    {
        [TestMethod]
        public void Test()
        {
            var UoW = CurrentServiceLocator.GetInstance<IDataServiceUnitOfWork>();

            var posts = UoW.DataAccessService.All<Post>();
            Assert.AreEqual(DummyPostData().Count(), posts.Count());
        }

        private IQueryable<Post> DummyPostData()
        {
            var list = new Post[] {
                new Post(){ Id = 1},
                new Post(){ Id = 2},
                new Post(){ Id = 3},
            };
            return list.AsQueryable();
        }
    }
}
