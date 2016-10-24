 using System.Collections.Generic;
using Domain.Product.Contracts;
using Domain.Product.Model;
using NHibernate;
using Data.Contracts;
using NHibernate.Linq;
using System;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly UnitOfWork unitOfWork;
        protected readonly ISession session;

        public ProductRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
            session = this.unitOfWork.GetSession();
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return session.Query<ProductModel>();
        }

        public ProductModel GetById(Guid id)
        {
            return session.Get<ProductModel>(id);
        }

        public void Create(ProductModel product)
        {
            session.Save(product);
        }

        public void Update(ProductModel product)
        {
            session.Update(product);
        }

        public void Delete(Guid id)
        {
            session.Delete(GetById(id));
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
