using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.DTOs
{
    public class DoctorDTO
    {
        public int ID {get;set;}
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Degree { get; set; }
        public string Qualifications { get; set; }
        public int SpecializationId { get; set; }
        public int ExperienceYears { get; set; }

        public double Rating { get; set; }
    }
}
