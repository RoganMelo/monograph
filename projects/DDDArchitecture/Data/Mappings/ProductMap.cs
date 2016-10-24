using Domain.Product.Model;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ProductMap : ClassMap<ProductModel>
    {
        public ProductMap()
        {
            Table("tb_product");

            Id(x => x.Id)
                .GeneratedBy
                .Assigned()
                .Length(128);

            Map(x => x.Name)
                .Not
                .Nullable()
                .Length(60);

            Map(x => x.Price)
                .Not
                .Nullable();

            Map(x => x.Quantity)
                .Not
                .Nullable();
        }
    }
}
