using EfExample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        IDataService _dataService;

        public CategoryController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            string url = Url.Link(nameof(GetCategory), new { id });

            var category = _dataService.GetCategory(id);
            if (category == null) return NotFound();
            
            return Ok(category);
        }

        [HttpPost(Name = nameof(CreateCategory))]
        public IActionResult CreateCategory([FromBody] Category model)
        {
            if (model == null) return BadRequest();

            var Category = _dataService.CreateCategory(model.Name, model.Description);
            //_dataService.CreatePerson(person);

            return Created(Url.RouteUrl(nameof(CreateCategory)).ToString(), Category);
        }

        
    }
}
