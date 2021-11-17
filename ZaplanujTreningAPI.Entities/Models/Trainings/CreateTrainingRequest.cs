using System.ComponentModel.DataAnnotations;

namespace ZaplanujTreningAPI.Entities.Models.Trainings
{
    public class CreateTrainingRequest
    {
        [Required]
        public string Name { get; set; }
    }
}