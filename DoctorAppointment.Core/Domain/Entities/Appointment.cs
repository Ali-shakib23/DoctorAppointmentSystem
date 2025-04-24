using DoctorAppointment.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class Appointment
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User? User { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID{ get;  set; }
        public Doctor? Doctor { get; set; }

        public AppointmentStatusEnum AppointmentStatus { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        public string AppointmentCode { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
