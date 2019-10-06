using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class DocsecRel
    {
        public int Id { get; set; }
        public int? SecId { get; set; }
        public int? DoctorId { get; set; }

        public virtual User Doctor { get; set; }
        public virtual User Sec { get; set; }
    }
}
