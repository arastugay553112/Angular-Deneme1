using API.Core.DbModels;
using API.Core.Interfaces;
using API.infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        /// <summary>
        /// Tüm ürünleri listeler
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return (IReadOnlyList<ProductType>)await _context.ProductType.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return (IReadOnlyList<ProductBrand>)await _context.ProductBrand.ToListAsync();
        }
    }
}
