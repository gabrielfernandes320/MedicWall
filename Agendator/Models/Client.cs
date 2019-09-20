using System;
using System.Collections.Generic;

namespace Agendator.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public int Role { get; set; }
        public string CellPhone { get; set; }

        public virtual Role RoleNavigation { get; set; }
    }
}
