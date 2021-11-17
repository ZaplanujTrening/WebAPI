using System.Collections.Generic;

namespace ZaplanujTreningAPI.Entities.Models.Trainings
{
    public class UpdateTrainingRequest
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public List<UpdateTrainingRoutineRequest> TrainingRoutines { get; set; }
    }
}
