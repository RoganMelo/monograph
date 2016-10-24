using System.Collections.Generic;
using Domain.Product.Model;
using Domain.Product.Contracts;
using Data.Contracts;
using System;

namespace Application.Product
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService service;

        public ProductApplicationService(IUnitOfWork unitOfWork, IProductService service)
        {
            this.unitOfWork = unitOfWork;
            this.service = service;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return service.GetAll();
        }

        public ProductModel GetById(Guid id)
        {
            return service.GetById(id);
        }

        public void Create(ProductModel product)
        {
            unitOfWork.BeginTransaction();

            service.Create(product);

            unitOfWork.Commit();
        }

        public void Update(ProductModel product)
        {
            unitOfWork.BeginTransaction();

            service.Update(product);

            unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            unitOfWork.BeginTransaction();

            service.Delete(id);

            unitOfWork.Commit();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            service.Dispose();
        }
    }
}
