using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Habbits.Data
{
    public class ToDoTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        public User User { get; set; }
    }
}