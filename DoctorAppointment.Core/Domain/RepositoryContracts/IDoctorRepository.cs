using DoctorAppointment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.RepositoryContracts
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsListsBySpecializationAsync(string specializationId);
      

        Task<List<Doctor>> GetDoctorByName(string doctorName);
       
       
    }
}
