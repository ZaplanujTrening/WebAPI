using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZaplanujTreningAPI.Core.Repositories.Interfaces;
using ZaplanujTreningAPI.Entities;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Core.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        private readonly DataContext _db;
        
        public ExerciseRepository(DataContext context) : base(context)
        {
            _db = Context;
        }

        public Exercise GetWhere(Expression<Func<Exercise, bool>> where)
        {
            return Get(where);
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = GetById(id);
            if(exercise != null)
                exercise.MusclePart = _db.MuscleParts.Single(a => a.Id == exercise.MusclePartId);

            return exercise;
        }

        public List<Exercise> GetExercises()
        {
            var exercises = GetAll().ToList();
            foreach(var exercise in exercises)
                exercise.MusclePart = _db.MuscleParts.Single(a => a.Id == exercise.MusclePartId);

            return exercises;
        }
    }
}
