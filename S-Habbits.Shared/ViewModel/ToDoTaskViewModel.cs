using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using S_Habbits.Data;

namespace S_Habbits.Shared.ViewModel
{
    public class ToDoTaskViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Message { get; set; }
        public bool IsChecked { get; set; }
        [IgnoreDataMember]
        public User User { get; set; }
    }
}