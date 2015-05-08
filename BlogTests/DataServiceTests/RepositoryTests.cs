using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBaseDataService.Implementation;
using Microsoft.Practices.ServiceLocation;
using BlogBaseDataService.Interfaces;
using BlogDatalayer;
using System.Linq;
using Microsoft.Practices.Unity;
using BlogBaseDatalayer.Interfaces;


namespace BlogTests.DataServiceTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Test()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IDataServiceUnitOfWork, DataServiceUnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDataAccessService, DataAccessService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDbContext, DataAccessService>(new ContainerControlledLifetimeManager());
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
            var UoW = ServiceLocator.Current.GetInstance<IDataServiceUnitOfWork>();
            var posts = UoW.DataAccessService.All<Post>();
            Assert.AreEqual(0, posts.Count());
        }
    }
}
