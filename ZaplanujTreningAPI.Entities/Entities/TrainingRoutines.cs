using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZaplanujTreningAPI.Entities.Entities
{
    public class TrainingRoutines
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Exercises")]
        public int ExercisesId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public TimeSpan Time { get; set; }
        public Training Training { get; set; }
        public Exercise Exercise { get; set; }
    }
}
