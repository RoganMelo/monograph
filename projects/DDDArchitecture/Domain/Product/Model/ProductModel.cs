using System;

namespace Domain.Product.Model
{
    public class ProductModel
    {
        public ProductModel() { }

        public ProductModel(string name, float price, int quantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }

        public virtual int Quantity { get; set; }

        public float GetTotal()
        {
            return Price * Quantity;
        }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(Name) ? false : true;
        }
    }
}
