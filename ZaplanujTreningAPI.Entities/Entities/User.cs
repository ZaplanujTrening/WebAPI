using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZaplanujTreningAPI.Entities.Entities
{
    public class User
    {
        public User()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime CreateDate { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
