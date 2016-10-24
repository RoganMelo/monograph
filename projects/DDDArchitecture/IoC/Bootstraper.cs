using Application.Product;
using Data;
using Data.Contracts;
using Data.Repositories;
using Domain.Product.Contracts;
using Domain.Product.Service;
using SimpleInjector;

namespace IoC
{
    public class Bootstraper
    {
        public static void RegisterServices(Container container)
        {
            // Application Services
            container.Register<IProductApplicationService, ProductApplicationService>(Lifestyle.Scoped);

            // UnitOfWork
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            // Repositories
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);

            //Services
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);
        }
    }
}
