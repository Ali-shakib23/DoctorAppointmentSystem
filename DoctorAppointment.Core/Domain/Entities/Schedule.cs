using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class Schedule
    {
        public int ID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor? Doctor { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }    // e.g., 09:00
        public TimeSpan EndTime { get; set; }      // e.g., 17:00
        public bool IsAvailable { get; set; }
    }
}
