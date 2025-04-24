using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class Specialization
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Doctor>? Doctors { get; set; }
    }
}
