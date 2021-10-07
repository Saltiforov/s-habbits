using System;
using System.Runtime.Serialization;
using S_Habbits.Data;

namespace S_Habbits.Shared.ViewModel
{
    public class HabbitEventViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsChecked { get; set; }
        [IgnoreDataMember]
        public Habbit Habbit { get; set; }
    }
}