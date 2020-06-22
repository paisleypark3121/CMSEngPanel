using AppSettings;
using BlobManager;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace CMSEngPanel
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountcmsen927e;AccountKey=X63IKbAfC70fS/jYBJPyyK3ofSFdUeKSyTvCxLiAEgrOe9US+ylyez8KnDIrQDxGx6M9WHY5dF5D2FrSb5mhXQ==;EndpointSuffix=core.windows.net";

            container.RegisterType<IAppSettings, AppSettings.AppSettings>(new ContainerControlledLifetimeManager());

            container.RegisterType<IBlobManager,BlobManager.BlobManager>(new InjectionConstructor(new object[] { connectionString }));            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}