using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Position { get; set; }          // e.g., Consultant, Specialist
        public string Degree { get; set; }            // e.g., MD, PhD
        public string Qualifications { get; set; }

        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
      
        public Specialization Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public double Rating { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
