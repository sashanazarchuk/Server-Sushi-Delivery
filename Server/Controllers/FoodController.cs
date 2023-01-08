using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Data.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService foodService;
        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(foodService.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var food = foodService.GetById(id);

            if (food == null) return NotFound();

            return Ok(food);
        }
        [HttpGet("Increase")]
        public IActionResult Increase()
        {
            var food = foodService.Increase();
            if (food == null) return NotFound();
            return Ok(food);
        }

        [HttpGet("Decrease")]
        public IActionResult Decrease()
        {
            var food = foodService.Decrease();
            if (food == null) return NotFound();
            return Ok(food);
        }

        [HttpGet("category-1")]
        public IActionResult Category1()
        {
            var food = foodService.Category1();
            if (food == null) return NotFound();
            return Ok(food);
        }
  
        [HttpGet("category-2")]
        public IActionResult Category2()
        {
            var food = foodService.Category2();
            if (food == null) return NotFound();
            return Ok(food);
        }
        [HttpGet("category-3")]
        public IActionResult Category3()
        {
            var food = foodService.Category3();
            if (food == null) return NotFound();
            return Ok(food);
        }

        [HttpGet("category-4")]
        public IActionResult Category4()
        {
            var food = foodService.Category4();
            if (food == null) return NotFound();
            return Ok(food);
        }

        [HttpGet("category-5")]
        public IActionResult Category5()
        {
            var food = foodService.Category5();
            if (food == null) return NotFound();
            return Ok(food);
        }


        [HttpPost]
        public IActionResult Create([FromBody] FoodDto food)
        {
            foodService.Create(food);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] FoodDto food)
        {
            foodService.Edit(food);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            foodService.Delete(id);

            return Ok();
        }
    }
}
