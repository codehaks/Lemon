using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Foods;
using Portal.Application.Foods.Models;

namespace Portal.Web.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [Route("api/food")]
        public IActionResult FindAll()
        {
            var model = _foodService.FindAll();
            return Ok(model);
        }

        [HttpPost]
        [Route("api/food")]
        public async Task<IActionResult> Create(FoodAddInfo model)
        {
            if (ModelState.IsValid)
            {
                await _foodService.Create(model);
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
      
        }

        [HttpGet]
        [Route("api/food/{id}")]
        public IActionResult FindById(int id)
        {
            var model = _foodService.FindById(id);
            return Ok(model);
        }
    }
}