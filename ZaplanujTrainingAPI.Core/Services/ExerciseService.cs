using System;
using System.Collections.Generic;
using System.Linq;
using ZaplanujTreningAPI.Core.Services.Interfaces;
using ZaplanujTreningAPI.Entities.Entities;
using ZaplanujTreningAPI.Entities.Models;
using ZaplanujTreningAPI.Entities.Models.Users;
using ZaplanujTreningAPI.Utils.Helpers;
using ZaplanujTreningAPI.Core.Repositories.Interfaces;

namespace ZaplanujTreningAPI.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _exerciseRepository.GetExercises();
        }
        public  Exercise GetById(int id)
        {
            var exercise = _exerciseRepository.GetExerciseById(id);
            if (exercise == null) throw new KeyNotFoundException("Exercise not found");
            return exercise;
        }
    }
}
