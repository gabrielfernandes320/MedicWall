using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public int Cpf { get; set; }
        public int Rg { get; set; }
        public string Crm { get; set; }

        public virtual User User { get; set; }
    }
}
