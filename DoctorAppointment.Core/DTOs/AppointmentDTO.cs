using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; }

        public AppointmentStatusEnum AppointmentStatus { get; set; } // Or use an enum if you prefer

        // Optional: include Doctor/User display info if needed
        public string DoctorName { get; set; }
        public string UserName { get; set; }

        public string AppointmentCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
