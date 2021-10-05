using System;

namespace S_Habbits.Data
{
    public class HabbitEvent
    {
        public HabbitEvent()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime CheckedTime { get; set; }
        public Habbit Habbit { get; set; }
    }
}