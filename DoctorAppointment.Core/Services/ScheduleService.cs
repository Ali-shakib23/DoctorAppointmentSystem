using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ScheduleService(IScheduleRepository scheduleRepository, IDoctorRepository doctorRepository)
        {
            _scheduleRepository = scheduleRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO scheduleDTO)
        {
            Schedule schedule = new Schedule
            {
                DoctorID = scheduleDTO.DoctorID,
                Day = scheduleDTO.Day,
                StartTime = scheduleDTO.StartTime,
                EndTime = scheduleDTO.EndTime,
                IsAvailable = scheduleDTO.IsAvailable
            };

            bool created = await _scheduleRepository.AddAsync(schedule);
            if (created)
            {
                // Fetch again to get the full Doctor object if needed
                var createdSchedule = await _scheduleRepository.GetByIdAsync(schedule.ID);
                return new ScheduleDTO
                {
                    ID = createdSchedule.ID,
                    DoctorID = createdSchedule.DoctorID,
                    Day = createdSchedule.Day,
                    StartTime = createdSchedule.StartTime,
                    EndTime = createdSchedule.EndTime,
                    IsAvailable = createdSchedule.IsAvailable,
                    DoctorName = createdSchedule.Doctor?.FullName
                };
            }

            return null;
        }

        public async Task<bool> UpdateScheduleAsync(int id, ScheduleDTO scheduleDTO)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
            {
                return false;
            }

            schedule.Day = scheduleDTO.Day;
            schedule.StartTime = scheduleDTO.StartTime;
            schedule.EndTime = scheduleDTO.EndTime;
            schedule.IsAvailable = scheduleDTO.IsAvailable;

            return await _scheduleRepository.UpdateAsync(schedule);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetDoctorScheduleAsync(int doctorId)
        {
            var schedules = await _scheduleRepository.GetSchedulesByDoctorIdAsync(doctorId);
            return schedules.Select(schedule => new ScheduleDTO
            {
                ID = schedule.ID,
                DoctorID = schedule.DoctorID,
                Day = schedule.Day,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable,
                DoctorName = schedule.Doctor?.FullName
            }).ToList();
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            return schedules.Select(schedule => new ScheduleDTO
            {
                ID = schedule.ID,
                DoctorID = schedule.DoctorID,
                Day = schedule.Day,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable,
                DoctorName = schedule.Doctor?.FullName
            }).ToList();
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            return await _scheduleRepository.DeleteAsync(id);
        }

        public async Task<ScheduleDTO> SetScheduleAvailabilityAsync(int id, bool isAvailable)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
            {
                return null;
            }

            schedule.IsAvailable = isAvailable;
            bool updated = await _scheduleRepository.UpdateAsync(schedule);

            if (!updated)
            {
                return null;
            }

            return new ScheduleDTO
            {
                ID = schedule.ID,
                DoctorID = schedule.DoctorID,
                Day = schedule.Day,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable,
                DoctorName = schedule.Doctor?.FullName
            };
        }
    }

}


