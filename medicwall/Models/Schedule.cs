using System;
using System.Collections.Generic;

namespace medicwall.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal? Price { get; set; }
        public bool? Canceled { get; set; }
        public string CanceledReason { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Observation { get; set; }

        public virtual User Doctor { get; set; }
        public virtual User Patient { get; set; }
    }
}
