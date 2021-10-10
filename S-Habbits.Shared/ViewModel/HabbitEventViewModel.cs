using System;
using System.Text.Json.Serialization;
using S_Habbits.Data.Models;

namespace S_Habbits.Shared.ViewModel
{
    public class HabbitEventViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsChecked { get; set; }

        [JsonIgnore] public Habbit Habbit { get; set; }
    }
}