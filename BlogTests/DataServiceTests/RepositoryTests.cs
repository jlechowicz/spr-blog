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
            Assert.AreEqual(0, posts.Count());
        }
    }
}
