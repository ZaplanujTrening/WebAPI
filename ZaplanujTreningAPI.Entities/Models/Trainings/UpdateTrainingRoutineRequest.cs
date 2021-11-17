using System;

namespace ZaplanujTreningAPI.Entities.Models.Trainings
{
    public class UpdateTrainingRoutineRequest
    {
        public int UserId { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
    }
}
