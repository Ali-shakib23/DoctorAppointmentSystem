using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Review>? Reviews { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
