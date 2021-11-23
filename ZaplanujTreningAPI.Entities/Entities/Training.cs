using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZaplanujTreningAPI.Entities.Entities
{
    public class Training
    {
        public Training()
        {
            DateAdded = DateTime.Now;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual User AddedBy { get; set; }
    }
}
