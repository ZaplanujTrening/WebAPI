using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZaplanujTreningAPI.Entities.Models.Trainings;

namespace ZaplanujTreningAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TrainingsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(CreateTrainingRequest model)
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
        public IActionResult Update(int id, UpdateTrainingRequest model)
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

        [HttpPost("{id}/start")]
        public IActionResult Start(int id)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [HttpPost("{id}/end")]
        public IActionResult End(int id)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }
    }
}
