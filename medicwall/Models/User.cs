using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class User
    {
        public User()
        {
            DocsecRelDoctor = new HashSet<DocsecRel>();
            DocsecRelSec = new HashSet<DocsecRel>();
            ScheduleDoctor = new HashSet<Schedule>();
            SchedulePatient = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public int FkContact { get; set; }
        public int FkDocument { get; set; }
        public int FkAdress { get; set; }
        public int? FkConfpaciente { get; set; }
        public int? FkConfmedico { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Adress FkAdressNavigation { get; set; }
        public virtual ConfDoctor FkConfmedicoNavigation { get; set; }
        public virtual ConfPatient FkConfpacienteNavigation { get; set; }
        public virtual Contact FkContactNavigation { get; set; }
        public virtual Document FkDocumentNavigation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<DocsecRel> DocsecRelDoctor { get; set; }
        public virtual ICollection<DocsecRel> DocsecRelSec { get; set; }
        public virtual ICollection<Schedule> ScheduleDoctor { get; set; }
        public virtual ICollection<Schedule> SchedulePatient { get; set; }
    }
}
