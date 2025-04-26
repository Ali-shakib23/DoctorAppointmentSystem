using DoctorAppointment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.RepositoryContracts
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
       
        Task<IEnumerable<Schedule>> GetSchedulesByDoctorIdAsync(int doctorId);
      
       
        Task<IEnumerable<Schedule>> BulkUploadSchedulesAsync(IEnumerable<Schedule> schedules);
        
        Task<bool> SetScheduleAvailabilityAsync(int id, bool isAvailable);
    }
}
