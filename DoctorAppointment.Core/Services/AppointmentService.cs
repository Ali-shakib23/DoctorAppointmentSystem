using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.Enums;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Services
{
    public class AppointmentService : IAppointmentService

    {
        private readonly IAppointmentRepository _appointmentRepository;
        //private readonly IGenericRepository<Appointment> _genericAppointmentRepository;
        private readonly IGenericRepository<User> _genericUserRepository;
        private readonly IGenericRepository<Doctor> _genericDoctorRepository;
        //private readonly IUserRepostory

        public AppointmentService(IAppointmentRepository appointmentRepository,
            
             IGenericRepository<User> genericUserRepository,
             IGenericRepository<Doctor> genericDoctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            
            _genericUserRepository = genericUserRepository;
            _genericDoctorRepository = genericDoctorRepository;
            
        }
        public async Task<bool> DeleteAppointmentByAdminAsync(int id)
        {
            return await _appointmentRepository.DeleteAsync(id);
        }

        public async Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO createDTO)
        {
            Appointment appointment = new Appointment
            {
                DoctorID = createDTO.DoctorId,
                UserID = createDTO.UserId,
                AppointmentDate = DateTime.UtcNow,
                Reason = createDTO.Reason,
                AppointmentStatus = AppointmentStatusEnum.Pending,
                CreatedAt = DateTime.UtcNow,
                AppointmentCode = $"APT-{Guid.NewGuid().ToString().Substring(0, 10)}"
            };
            if (await _appointmentRepository.AddAsync(appointment))
            {
                return await GetAppointmentByIdAsync(appointment.ID);
            }
            return null;
        }

        
        public async Task<AppointmentDTO> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            AppointmentDTO appointmentDto = new AppointmentDTO
            {
                Id = appointment.ID,
                UserId = appointment.UserID,
                DoctorId = appointment.DoctorID,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                AppointmentStatus = appointment.AppointmentStatus,
                DoctorName = appointment.Doctor.FullName,
                UserName = appointment.User.FullName,
                CreatedAt = appointment.CreatedAt,
                AppointmentCode = appointment.AppointmentCode,
            };
            return appointmentDto;
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);
            List<AppointmentDTO> appointmentDTOs = appointments.Select(x => new AppointmentDTO
            {
                Id = x.ID,
                UserId = x.UserID,
                DoctorId = x.DoctorID,
                AppointmentDate = x.AppointmentDate,
                Reason = x.Reason,
                AppointmentStatus = x.AppointmentStatus,
                DoctorName = x.Doctor.FullName,
                UserName = x.User.FullName
            }).ToList();
            return appointmentDTOs;
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsByUserIdAsync(int userId)
        {
            var appointments =  await _appointmentRepository.GetAppointmentsByUserIdAsync(userId);
            List<AppointmentDTO> appointmentDTOs = appointments.Select(x => new AppointmentDTO
            {
                Id = x.ID,
                UserId = x.UserID,
                DoctorId = x.DoctorID,
                AppointmentDate = x.AppointmentDate,
                Reason = x.Reason,
                AppointmentStatus = x.AppointmentStatus, 
                DoctorName = x.Doctor.FullName,
                UserName = x.User.FullName
            }).ToList();
            return appointmentDTOs;
        }

        public async Task<bool> UpdateAppointment(int id , AppointmentDTO appointmentDTO)
        {
            Appointment appointment = await _appointmentRepository.GetByIdAsync(id);

            if(appointment == null)
            {
                return false;
            }

            if (!IsAppointmentCancelable(appointment.AppointmentDate))
            {
                return false;
            }
            appointment.AppointmentDate = appointmentDTO.AppointmentDate;
            appointment.AppointmentStatus = appointmentDTO.AppointmentStatus;
            appointment.Doctor.FullName = appointmentDTO.DoctorName;
            appointment.Reason = appointmentDTO.Reason;
            appointment.User.FullName = appointmentDTO.UserName;

            bool updated = await _appointmentRepository.UpdateAsync(appointment);
            return updated;
        
    }

        public async Task<(bool success, string? message)> UpdateAppointmentStatusAsync(int id, AppointmentStatusEnum newStatus)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            // If appointment not found, return false
            if (appointment == null)
            {
                return (false, "not found");
            }

            // Check if the appointment is not less than 2 days away
            if (!IsAppointmentCancelable(appointment.AppointmentDate))
            {
                return (false, "Appointment cannot be updated within 2 days of the scheduled date"); // Cannot update if the appointment is within 2 days
            }

            // If the status is already the same as the new status, no need to update
            if (appointment.AppointmentStatus == newStatus)
            {
                return (true, "updated"); // No change needed, status is already correct
            }

            // Update the status of the appointment
            appointment.AppointmentStatus = newStatus;
            bool updated = await _appointmentRepository.UpdateAsync(appointment);
            return (updated, updated ? null : "Failed to update appointment");

        }

        public async Task<(bool Success, string? Message)> RejectAppointmentByDoctorAsync(int id)
        {
            return await UpdateAppointmentStatusAsync(id, AppointmentStatusEnum.Rejected);
        }

        public async Task<(bool Success, string? Message)> ApproveAppointmentByDoctorAsync(int id)
        {
            return await UpdateAppointmentStatusAsync(id, AppointmentStatusEnum.Approved);
        }

        public async Task<(bool Success, string? Message)> CancelAppointmentAsync(int id)
        {
        
           return await UpdateAppointmentStatusAsync(id, AppointmentStatusEnum.Canceled);
        }

        private bool IsAppointmentCancelable(DateTime appointmentDate)
        {
            return appointmentDate > DateTime.Now.AddDays(2); 
        }

        
    }
}
