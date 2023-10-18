﻿using FlowerSales.Models;
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

        private readonly IMongoCollection<Product> _productCollection;

        public FlowersController(MongoDBContext mongoDbService)
        {
            _productCollection = mongoDbService._productCollection;            
        }

        //[HttpGet]
        //[Route("test")]
        //public async Task<ActionResult> GetAll2()
        //{
        //    return Ok(_productCollection.AsQueryable());
        //}

        //// Async method on IQueryable do not support ToListAsync with System.InvalidOperationException.
        //// This method work without async and mainly IActionResult or ActionResult
        //[HttpGet]
        //[Route("test2")]
        //public async Task<ActionResult> GetAllProducts2([FromQuery] ProductQueryParameters queryParameters)
        //{
        //    IQueryable<Product> products = _productCollection.AsQueryable();

        //    if (queryParameters.MinPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.price >= queryParameters.MinPrice.Value);
        //    }

        //    if (queryParameters.MaxPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.price <= queryParameters.MaxPrice.Value);
        //    }

        //    if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
        //    {
        //        products = products.Where(
        //            p => p.categoryName.ToLower().Contains(queryParameters.SearchTerm.ToLower()) ||
        //                 p.name.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
        //    }


        //    if (!string.IsNullOrEmpty(queryParameters.Name))
        //    {
        //        products = products.Where(
        //            p => p.name.ToLower().Contains(
        //                queryParameters.Name.ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(queryParameters.SortBy) && queryParameters.SortOrder == "asc")
        //    {
        //        products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
        //    }

        //    products = products                
        //            .Skip(queryParameters.Size * (queryParameters.Page - 1))
        //            .Take(queryParameters.Size);
                    

        //    return Ok(await products.ToListAsync());
        //}

        [HttpGet]        
        public async Task<ActionResult> GetAllProducts([FromQuery] ProductQueryParameters queryParameters)
        {
            var filter = Builders<Product>.Filter.Empty;

            if (queryParameters.MinPrice != null)
            {
                filter &= Builders<Product>.Filter.Gte(p => p.price, queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                filter &= Builders<Product>.Filter.Lte(p => p.price, queryParameters.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                string searchTerm = queryParameters.SearchTerm.ToLower();
                filter &= Builders<Product>.Filter.Or(
                    Builders<Product>.Filter.Where(p => p.categoryName.ToLower().Contains(searchTerm)),
                    Builders<Product>.Filter.Where(p => p.name.ToLower().Contains(searchTerm))
                );
            }

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                string name = queryParameters.Name.ToLower();
                filter &= Builders<Product>.Filter.Where(p => p.name.ToLower().Contains(name));
            }

            var sortDefinition = queryParameters.SortOrder == "asc"
                ? Builders<Product>.Sort.Ascending(queryParameters.SortBy)
                : Builders<Product>.Sort.Descending(queryParameters.SortBy);

            var products = await _productCollection.Find(filter)
                .Sort(sortDefinition)
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Limit(queryParameters.Size)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id); // Assuming _id is of type string

            var product = await _productCollection.Find(filter).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }   

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productCollection.InsertOneAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product._id }, product);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put([FromBody] Product updatedProduct, string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id); // Create a filter to find the product by ID

            var existingProduct = await _productCollection.Find(filter).FirstOrDefaultAsync();

            if (existingProduct == null)
            {
                return NotFound(); // Product not found
            }

            // Update the fields of the existing product with the fields of the updated product
            existingProduct.name = updatedProduct.name;
            existingProduct.storeLocation = updatedProduct.storeLocation;
            existingProduct.postcode = updatedProduct.postcode;
            existingProduct.price = updatedProduct.price;
            existingProduct.isAvailable = updatedProduct.isAvailable;
            existingProduct.categoryName = updatedProduct.categoryName;

            // Save the updated product back to the database
            var result = await _productCollection.ReplaceOneAsync(filter, existingProduct);

            if (result.IsAcknowledged && result.ModifiedCount > 0)
            {
                return Ok(existingProduct); // Return the updated product
            }
            else
            {
                return BadRequest(); // Something went wrong while updating
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string? id, [FromQuery] string? name)
        {
            // Create a filter by either id or name
             var filter = Builders<Product>.Filter.Or(
                Builders<Product>.Filter.Eq("_id", id),
                Builders<Product>.Filter.Eq("name", name)
            );

            // Delete the filter from the database
            var result = await _productCollection.DeleteOneAsync(filter);

            if(result.DeletedCount == 0)
            {
                return NotFound(); // Return notfound if none deleted
            }

            return NoContent();
        }


    }
}
