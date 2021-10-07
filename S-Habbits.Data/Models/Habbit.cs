using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Habbits.Data
{
    public class Habbit
    {
        public Habbit()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public int RewardPoints { get; set; }
        [Required]
        public User User { get; set; }
    }
}