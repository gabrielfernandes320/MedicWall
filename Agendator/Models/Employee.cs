using System;
using System.Collections.Generic;

namespace Agendator.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public int Role { get; set; }
        public string CellPhone { get; set; }
        public int Specialty { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public TimeSpan StartWorkTime { get; set; }
        public TimeSpan EndWorkTime { get; set; }
        public decimal AppointmentValue { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual Specialty SpecialtyNavigation { get; set; }
    }
}
