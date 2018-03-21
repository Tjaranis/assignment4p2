﻿using EfExample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /*
        [HttpGet]
        public IActionResult GetCategories()
        {
            var persons = _dataService.GetPersons().Select(x =>
            {
                var model = new PersonListModel { Name = x.Name };
                model.Url = Url.Link(nameof(GetPerson), new { x.Id });
                return model;
            });
            return Ok(persons);
        }
        /*
        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = _dataService.GetPersons().Select(x =>
            {
                var model = new PersonListModel { Name = x.Name };
                model.Url = Url.Link(nameof(GetPerson), new { x.Id });
                return model;
            });
            return Ok(persons);
        }

        [HttpGet("{id}", Name = nameof(GetPerson))]
        public IActionResult GetPerson(int id)
        {
            var person = _dataService.GetPerson(id);
            if (person == null) return NotFound();


            var model = new PersonModel
            {
                Url = Url.Link(nameof(GetPerson), new { id }),
                Name = person.Name,
                Age = person.Age
            };

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreatePersonModel model)
        {
            if (model == null) return BadRequest();

            var person = new Person
            {
                Name = model.Name,
                Age = model.Age
            };

            _dataService.CreatePerson(person);

            return Ok(person);
        }
        */
    }
}
