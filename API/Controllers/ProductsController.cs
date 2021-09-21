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
        private readonly IProductRepository _ProductRepository;
        public ProductsController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
           // _context = context;
        }

        [HttpGet] //http-verbs
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _ProductRepository.GetProductAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _ProductRepository.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductRepository.GetProductBrandAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _ProductRepository.GetProductTypesAsync());
        }
    }
}
