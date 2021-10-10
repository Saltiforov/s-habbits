using System;
using System.Text.Json.Serialization;
using S_Habbits.Data.Models;

namespace S_Habbits.Shared.ViewModel
{
    public class HabbitViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int RewardPoints { get; set; }

        [JsonIgnore] public User User { get; set; }

        public HabbitEventViewModel LastHabbitEvent { get; set; }
    }
}