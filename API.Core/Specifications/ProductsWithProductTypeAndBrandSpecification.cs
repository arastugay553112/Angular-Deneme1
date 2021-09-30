using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification()
        {
            AddIclude(X => X.ProductType);
            AddIclude(X => X.ProductBrand);
        }
        public ProductsWithProductTypeAndBrandSpecification(int id)
            :base(x=>x.id == id)
        {
            AddIclude(X => X.ProductType);
            AddIclude(X => X.ProductBrand);
        }
    }
}
