using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Habbits.Data.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        public int Points { get; set; }
    }
}