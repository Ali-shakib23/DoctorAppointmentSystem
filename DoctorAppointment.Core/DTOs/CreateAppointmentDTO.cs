using DoctorAppointment.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.DTOs
{
    public class CreateAppointmentDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DoctorId { get; set; }

        public string Reason { get; set; }

    }
}
