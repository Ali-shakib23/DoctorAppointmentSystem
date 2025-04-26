using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.DTOs
{
    public class ScheduleDTO
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }

    }
}
