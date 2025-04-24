using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.Entities
{
    public class Review
    {        
        //id
        public int ID { get; set; }
        
        //comment
        public string Comment { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
      
        public User? User { get; set; }
        //DoctorID

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        //CreatedAt
        public DateTime CreatedAt { get; set; }
        //Rating
        public int Rating { get; set; }
    }
}
