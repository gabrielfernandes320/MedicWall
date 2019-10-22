using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class ConfPatient
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public string Allergies { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual User User { get; set; }
    }
}
