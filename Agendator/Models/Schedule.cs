using System;
using System.Collections.Generic;

namespace Agendator.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClientId { get; set; }
        public TimeSpan AppointmentStartTime { get; set; }
        public decimal ExpectedPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool Canceled { get; set; }
        public string CanceledReason { get; set; }
        public TimeSpan AppointmentEndTime { get; set; }
        public DateTime Appointmentdate { get; set; }
    }
}
