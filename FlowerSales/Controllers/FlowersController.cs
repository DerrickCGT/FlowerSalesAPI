using FlowerSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly FlowerDBContext _flowerContext;

        public FlowersController(FlowerDBContext flowerContext)
        {
            _flowerContext = flowerContext;
            _flowerContext.Database.EnsureCreated();
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(_flowerContext.Products);
        }

        [HttpGet, Route("/getList")]
        public ActionResult GetList([FromQuery] int[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = _flowerContext.Products.Find(id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }


            
            return Ok(products);
        }


        [HttpGet, Route("/{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _flowerContext.Products.Find(id);
            return Ok(product);
        }

        [HttpGet, Route("/test/{id}")]
        public Product GetProduct2(int id)
        {
            var product = _flowerContext.Products.Find(id);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _flowerContext.Products.Add(product);
            await _flowerContext.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(Product product, int id)
        {
            if ( id != product.Id)
            {
                return BadRequest();
            }

            _flowerContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _flowerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_flowerContext.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}
