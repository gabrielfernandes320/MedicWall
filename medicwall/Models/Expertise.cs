using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class Expertise
    {
        public Expertise()
        {
            ConfDoctor = new HashSet<ConfDoctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConfDoctor> ConfDoctor { get; set; }
    }
}
