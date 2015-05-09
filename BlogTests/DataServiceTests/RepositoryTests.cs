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
            using (ServiceDataAccessHandler)
            {
                var posts = DataServiceUnitOfWork.DataAccessService.All<Post>();
                Assert.AreEqual(DummyPostData().Count(), posts.Count());
            }
        }

        private IQueryable<Post> DummyPostData()
        {
            var list = new Post[] {
               
            };
            return list.AsQueryable();
        }
    }
}
