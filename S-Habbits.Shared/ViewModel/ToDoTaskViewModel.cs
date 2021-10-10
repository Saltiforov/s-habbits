using System;
using System.Text.Json.Serialization;
using S_Habbits.Data.Models;

namespace S_Habbits.Shared.ViewModel
{
    public class ToDoTaskViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Message { get; set; }
        public bool IsChecked { get; set; }

        [JsonIgnore] public User User { get; set; }
    }
}