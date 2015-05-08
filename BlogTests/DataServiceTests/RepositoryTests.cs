using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBaseDataService.Implementation;
using Microsoft.Practices.ServiceLocation;
using BlogBaseDataService.Interfaces;
using BlogDatalayer;
using System.Linq;


namespace BlogTests.DataServiceTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Test()
        {
            var UoW = ServiceLocator.Current.GetInstance<IDataServiceUnitOfWork>();
            var posts = UoW.DataAccessService.All<Post>();
            Assert.AreEqual(0, posts.Count());
        }
    }
}
