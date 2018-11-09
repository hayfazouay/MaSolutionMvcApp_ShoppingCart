using ClassLibrary1ShoppingCart.Core.Domain;
using ClassLibrary1ShoppingCart.Core.Facade;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ShoppingCart.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var mockProducts = new Mock<IProductsRepository>();
            mockProducts.Setup(m => m.FindAll()).Returns(
                new List<Product>
                {
                    new Product {ProductId = "P1000", Name = "Café", PhotoFile="Cafe.jpg", UnitPrice=1.5M},
                    new Product {ProductId = "P2000", Name = "Thé", PhotoFile="The.jpg", UnitPrice=2M},
                    new Product {ProductId = "P3000", Name = "Chocolat", PhotoFile="Chocolat.jpg", UnitPrice=3M},
                    new Product {ProductId = "P4000", Name = "Gateau", PhotoFile="Gateau.jpg", UnitPrice=3.5M},
                }
                );

            container.RegisterInstance<IProductsRepository>(mockProducts.Object);
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}