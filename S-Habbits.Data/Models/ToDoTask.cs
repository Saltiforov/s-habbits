using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Habbits.Data
{
    public class ToDoTask
    {
        public ToDoTask()
        {
            Id=Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        [Required]
        public User User { get; set; }
    }
}