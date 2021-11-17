using System.ComponentModel.DataAnnotations;

namespace ZaplanujTreningAPI.Entities.Models.Exercises
{
    public class CreateExerciseRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int MusclePartId { get; set; }
    }
}
