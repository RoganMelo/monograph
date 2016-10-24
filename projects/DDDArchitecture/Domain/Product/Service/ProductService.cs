using System;
using System.Collections.Generic;
using Domain.Product.Contracts;
using Domain.Product.Model;

namespace Domain.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return repository.GetAll();
        }

        public ProductModel GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public void Create(ProductModel viewData)
        {
            var product = new ProductModel(viewData.Name, viewData.Price, viewData.Quantity);

            if (product.IsValid())
                repository.Create(product);
        }

        public void Update(ProductModel product)
        {
            if (product.IsValid())
                repository.Update(product);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
