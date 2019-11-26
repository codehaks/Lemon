using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.FoodApplication.Commands.Create;
using Portal.Application.FoodApplication.Queries.FindAll;
using Portal.Application.Foods;
using Portal.Application.Foods.Models;

namespace Portal.Web.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IMediator _mediator;

        public FoodController(IFoodService foodService, IMediator mediator)
        {
            _foodService = foodService;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/food")]
        public async Task<IActionResult> FindAll()
        {
            var model = await _mediator.Send(new FindAllFoodsQuery());
            return Ok(model);
        }

        [HttpPost]
        [Route("api/food")]
        public async Task<IActionResult> Create(FoodAddInfo model)
        {
            if (ModelState.IsValid)
            {
                //await _foodService.Create(model);
                //return Ok(model);

                var result=await _mediator.Send(new FoodCreateCommand
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    FoodType = model.FoodType
                });

                return Ok(result);
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