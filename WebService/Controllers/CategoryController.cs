﻿using EfExample;
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
            if (categories == null) return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            //is not used yet
            //string url = Url.Link(nameof(GetCategory), new { id });
            var category = _dataService.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost(Name = nameof(CreateCategory))]
        public IActionResult CreateCategory([FromBody] Category model)
        {
            if (model == null) return BadRequest();
            var Category = _dataService.CreateCategory(model.CategoryName, model.Description);
            return Created(Url.RouteUrl(nameof(CreateCategory)).ToString()+"/"+Category.Id, Category);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var exist = _dataService.GetCategory(id);
            if (exist == null) return NotFound();

            _dataService.DeleteCategory(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] Category model)
        {
            var exist=_dataService.GetCategory(model.Id);
            if (exist == null) return NotFound();

            _dataService.UpdateCategory(model.Id, model.CategoryName, model.Description);
            return Ok();
        }
    }
}
