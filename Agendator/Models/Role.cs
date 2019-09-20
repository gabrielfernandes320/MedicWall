using System;
using System.Collections.Generic;

namespace Agendator.Models
{
    public partial class Role
    {
        public Role()
        {
            Client = new HashSet<Client>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
