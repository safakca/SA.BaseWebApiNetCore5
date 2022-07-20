using BaseWebApi.Entities; 
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BaseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        //api/products/getProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,Product product)
        {
            var updateProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            updateProduct.Name = product.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(deleteProduct);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Created("",product);
        }

    }
}
