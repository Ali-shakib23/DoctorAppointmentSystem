using DoctorAppointment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.ServiceContracts
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO scheduleDTO);
        Task<bool> UpdateScheduleAsync(int id, ScheduleDTO scheduleDTO);
        Task<IEnumerable<ScheduleDTO>> GetDoctorScheduleAsync(int doctorId);
        Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync();
        Task<bool> DeleteScheduleAsync(int id);
        //Task<IEnumerable<AvailableTimeSlotDTO>> GetAvailableTimeSlotsAsync(int doctorId, DateTime date);
        //Task<IEnumerable<ScheduleDTO>> BulkUploadSchedulesAsync(List<ScheduleDTO> scheduleDTOs);
        Task<ScheduleDTO> SetScheduleAvailabilityAsync(int id, bool isAvailable);
    }
}
