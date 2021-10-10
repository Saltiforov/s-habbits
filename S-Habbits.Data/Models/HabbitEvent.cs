using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Habbits.Data.Models
{
    public class HabbitEvent
    {
        public HabbitEvent()
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required] public DateTime DateTime { get; set; }

        [Required] public bool IsChecked { get; set; }

        [Required] public Habbit Habbit { get; set; }
    }
}