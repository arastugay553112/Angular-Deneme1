using API.Core.DbModels;
using API.Core.Interfaces;
using API.infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    //https:localhost/5001/api/Products/GetProduct
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly StoreContext _context;
        // private readonly IProductRepository _ProductRepository;
        private readonly IGenericRepository1<Product> _ProductRepository;
        private readonly IGenericRepository1<ProductBrand> _ProductBrandRepository;
        private readonly IGenericRepository1<ProductType> _ProductTypeRepository;
        public ProductsController(IGenericRepository1<Product> ProductRepository, IGenericRepository1<ProductBrand> ProductBrandRepository, IGenericRepository1<ProductType> ProductTypeRepository)
           {
         _ProductRepository = ProductRepository;
            _ProductBrandRepository = ProductBrandRepository;
            _ProductTypeRepository = ProductTypeRepository;
            // _context = context;
        }
        

        [HttpGet] //http-verbs
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _ProductRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _ProductRepository.GetByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductBrandRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepository.ListAllAsync());
        }
    }
}
