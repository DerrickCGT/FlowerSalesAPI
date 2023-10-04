using FlowerSales.Models;
using FlowerSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlowerSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {

        private readonly MongoDBContext _mongoDbService;

        public FlowersController(MongoDBContext mongoDbService)
        {
            _mongoDbService = mongoDbService;            
        }


        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _mongoDbService._categoryCollection.Find(new BsonDocument()).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await _mongoDbService._categoryCollection.InsertOneAsync(category);           
            
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        //[HttpGet]
        //public async Task<ActionResult> GetAllProducts()
        //{
        //    return Ok(_flowerContext.ProductsEF);
        //}

        //[HttpGet, Route("/getList")]
        //public ActionResult GetList([FromQuery] int[] ids)
        //{
        //    var products = new List<Product>();
        //    foreach (var id in ids)
        //    {
        //        var product = _flowerContext.Products.Find(id);

        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        products.Add(product);
        //    }



        //    return Ok(products);
        //}


        //[HttpGet, Route("/{id}")]
        //public ActionResult GetProduct(int id)
        //{
        //    var product = _flowerContext.Products.Find(id);
        //    return Ok(product);
        //}

        //[HttpGet, Route("/test/{id}")]
        //public Product GetProduct2(int id)
        //{
        //    var product = _flowerContext.Products.Find(id);
        //    return product;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _flowerContext.Products.Add(product);
        //    await _flowerContext.SaveChangesAsync();
        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Product>> PutProduct(Product product, int id)
        //{
        //    if ( id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _flowerContext.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _flowerContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_flowerContext.Products.Any(p => p.Id == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}
    }
}
