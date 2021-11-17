namespace ZaplanujTreningAPI.Entities.Models.Exercises
{
    public class UpdateExerciseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MusclePartId { get; set; }
    }
}
