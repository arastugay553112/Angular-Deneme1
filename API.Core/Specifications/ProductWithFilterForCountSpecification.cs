using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Specifications
{
    public class ProductWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productspecparams) 
            :base(x=>
            (string.IsNullOrWhiteSpace(productspecparams.Saerch) || x.Name.ToLower().Contains(productspecparams.Saerch))
            &&
            (!productspecparams.BrandId.HasValue || x.ProductBrandId== productspecparams.BrandId)
            &&
            (!productspecparams.TypeId.HasValue || x.ProductTypeId== productspecparams.TypeId)
            )
        {

        }
    }
}
