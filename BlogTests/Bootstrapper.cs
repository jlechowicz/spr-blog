using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BlogBaseDataService.Interfaces;
using BlogBaseDatalayer.Interfaces;
using BlogDatalayer;
using BlogBaseDataService.Implementation;

namespace BlogTests
{
    [TestClass]
    public class Bootstrapper
    {
        static UnityContainer _container = null;

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            UnityContainer _container = new UnityContainer();
            _container.RegisterType<IDataServiceUnitOfWork, DataServiceUnitOfWork>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDataAccessService, DataAccessService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDbContext, BlogDatabaseEntities>(new ContainerControlledLifetimeManager());
            UnityServiceLocator locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            _container.Dispose();
        }
    }
}
