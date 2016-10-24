using System;

namespace SimpleArchitecture.Models
{
    public class ProductModel
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public virtual int Quantity { get; set; }
    }
}
