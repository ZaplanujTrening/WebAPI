using System.Collections.Generic;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Core.Services.Interfaces
{
    public interface IExerciseService
    {
        IEnumerable<Exercise> GetAll();
        Exercise GetById(int id);
    }
}
