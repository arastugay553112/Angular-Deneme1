using API.Core.DbModels;
using System;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification(ProductSpecParams productSpecParams)
            :base(x=>
            (string.IsNullOrWhiteSpace(productSpecParams.Saerch) || x.Name.ToLower().Contains(productSpecParams.Saerch)) 
            &&
            (!productSpecParams.BrandId.HasValue || x.ProductBrandId== productSpecParams.BrandId)
            &&
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId== productSpecParams.TypeId)
            )
        {
            AddIclude(X => X.ProductType);
            AddIclude(X => X.ProductBrand);
            // AddOrderBy(x => x.Name);

            ApplyPaging(productSpecParams.PageSize*(productSpecParams.PageIndex-1),productSpecParams.PageSize);
            if (!String.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
        public ProductsWithProductTypeAndBrandSpecification(int id)
            :base(x=>x.id == id)
        {
            AddIclude(X => X.ProductType);
            AddIclude(X => X.ProductBrand);
        }
    }
}
