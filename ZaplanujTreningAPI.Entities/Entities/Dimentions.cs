using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZaplanujTreningAPI.Entities.Entities
{
    public class Dimentions
    {
        public Dimentions()
        {
            DateAdded = DateTime.Now;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Chest { get; set; }
        public string Biceps { get; set; }
        public string Waist { get; set; }
        public string Hips { get; set; }
        public string Thigh { get; set; }
        public string Calf { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual User User { get; set; }
    }
}
