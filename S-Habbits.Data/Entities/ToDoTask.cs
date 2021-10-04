using System;

namespace S_Habbits.Entities.Entities
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public bool IsChecked { get; set; }
        
    }
}