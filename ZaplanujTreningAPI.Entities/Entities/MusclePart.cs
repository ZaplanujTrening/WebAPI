using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZaplanujTreningAPI.Entities.Entities
{
    public class MusclePart
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string PartName { get; set; }
    }
}
