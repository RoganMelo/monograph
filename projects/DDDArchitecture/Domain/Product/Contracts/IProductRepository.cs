using Domain.Product.Model;
using System;
using System.Collections.Generic;

namespace Domain.Product.Contracts
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductModel> GetAll();

        ProductModel GetById(Guid id);

        void Create(ProductModel product);

        void Update(ProductModel product);

        void Delete(Guid id);
    }
}
