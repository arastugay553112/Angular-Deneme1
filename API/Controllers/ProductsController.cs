using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository1<Product> ProductRepository, IGenericRepository1<ProductBrand> ProductBrandRepository, IGenericRepository1<ProductType> ProductTypeRepository
            ,IMapper mapper)
           {
         _ProductRepository = ProductRepository;
            _ProductBrandRepository = ProductBrandRepository;
            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
            // _context = context;
        }
        

        [HttpGet] //http-verbs
        public async Task<ActionResult<IReadOnlyList<ProductToolReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification();
            var data = await _ProductRepository.ListAsync(spec);
            // return Ok(data);
            /*  return data.Select(pro => new ProductToolReturnDto
              {
                  id = pro.id,
                  Name = pro.Name,
                  Description = pro.Description,
                  PictureUrl = pro.PictureUrl,
                  Price = pro.Price,
                  ProductBrand = pro.ProductBrand.Name != null ? pro.ProductBrand.Name : string.Empty,
                  ProductType = pro.ProductType.Name != null ? pro.ProductType.Name : string.Empty
              }).ToList();
         */
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToolReturnDto>>(data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToolReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(id);
            //  return await _ProductRepository.GetEntityWithSpec(spec);
            var product = await _ProductRepository.GetEntityWithSpec(spec);
           /* return new ProductToolReturnDto
            {
                id = product.id,
            Name = product.Name,
            Description=product.Description,
            PictureUrl=product.PictureUrl,
            Price=product.Price,
            ProductBrand=product.ProductBrand.Name!=null ? product.ProductBrand.Name : string.Empty,
            ProductType=product.ProductType.Name != null ? product.ProductType.Name : string.Empty
            };*/
            return _mapper.Map<Product, ProductToolReturnDto>(product);
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
