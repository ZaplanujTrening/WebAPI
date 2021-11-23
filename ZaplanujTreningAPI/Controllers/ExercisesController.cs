using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ZaplanujTreningAPI.Core.Services.Interfaces;
using ZaplanujTreningAPI.Entities.Models.Exercises;

namespace ZaplanujTreningAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/exercise")]
    public class ExercisesController : ControllerBase
    {
        private IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(CreateExerciseRequest model)
        {
            //TODO
            return Ok(new { message = "TODO" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var exercises = _exerciseService.GetAll();
            return Ok(exercises);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var exercise = _exerciseService.GetById(id);
            return Ok(exercise);
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
