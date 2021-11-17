using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZaplanujTreningAPI.Entities.Models.Exercises;

namespace ZaplanujTreningAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(CreateExerciseRequest model)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateExerciseRequest model)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpGet("muscle-parts")]
        public IActionResult GetMuscleParts()
        {
            //TODO
            return Ok(new { message = "TODO" });
        }
    }
}
