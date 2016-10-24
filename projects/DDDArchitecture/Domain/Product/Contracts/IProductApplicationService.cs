using Domain.Product.Model;
using System;
using System.Collections.Generic;

namespace Domain.Product.Contracts
{
    public interface IProductApplicationService : IDisposable
    {
        IEnumerable<ProductModel> GetAll();

        ProductModel GetById(Guid id);

        void Create(ProductModel product);

        void Update(ProductModel updatedProduct);

        void Delete(Guid id);
    }
}
