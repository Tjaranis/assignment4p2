using EfExample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        IDataService _dataService;

        public ProductController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id:int}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            //is not used yet
            //string url = Url.Link(nameof(GetProduct), new { id });
            var Product = _dataService.GetProduct(id);
            if (Product == null) return NotFound();
            return Ok(Product);
        }
        
        [HttpGet("category/{id:int}")]
        public IActionResult GetProductByCategory(int id)
        {
            //is not used yet
            //string url = Url.Link(nameof(GetProduct), new { id });
            var Products = _dataService.GetProductByCategory(id);
            if (_dataService.GetCategory(id) == null) return NotFound(Products);

            return Ok(Products);
        }
        
        /*
        [HttpPost(Name = nameof(CreateProduct))]
        public IActionResult CreateProduct([FromBody] Product model)
        {
            if (model == null) return BadRequest();
            var Product = _dataService.CreateProduct(model.Name, model.Description);
            return Created(Url.RouteUrl(nameof(CreateProduct)).ToString() + "/" + Product.Id, Product);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var exist = _dataService.GetProduct(id);
            if (exist == null) return NotFound();

            _dataService.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody] Product model)
        {
            var exist = _dataService.GetProduct(model.Id);
            if (exist == null) return NotFound();

            _dataService.UpdateProduct(model.Id, model.Name, model.Description);
            return Ok();
        }
        */
    }
}
