using System;
using System.Collections.Generic;

namespace Agendator.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
