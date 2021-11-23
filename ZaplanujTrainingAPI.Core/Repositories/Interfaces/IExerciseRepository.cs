using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Core.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Exercise GetWhere(Expression<Func<Exercise, bool>> where);
        Exercise GetExerciseById(int id);
        List<Exercise> GetExercises();
        void Add(Exercise user);
        void Update(Exercise user);
        void SaveChanges();
    }
}
