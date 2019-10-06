using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class ConfDoctor
    {
        public int Id { get; set; }
        public int FkEspec { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ConsultTime { get; set; }
        public int Price { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Expertise FkEspecNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
