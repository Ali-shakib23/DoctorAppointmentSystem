using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DoctorId { get; set; }

        public string Comment { get; set; }

       public int Rating { get; set; } // e.g. 1-5 stars

        public DateTime CreatedAt { get; set; }

        // Optional: to display user/doctor names
        public string UserName { get; set; }

        public string DoctorName { get; set; }
    }
}
