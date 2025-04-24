using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointment.Core.Domain.Enums;

namespace DoctorAppointment.Core.ServiceContracts
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> GetAppointmentByIdAsync(int id);
        Task<List<AppointmentDTO>> GetAppointmentsByUserIdAsync(int userId);
        Task<List<AppointmentDTO>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO dto);
       
        Task<bool> UpdateAppointment(int id, AppointmentDTO appointmentDTO);
        Task<(bool success, string? message)> UpdateAppointmentStatusAsync(int id, AppointmentStatusEnum newStatus);

        Task<bool> DeleteAppointmentByAdminAsync(int id);
        Task<(bool Success, string? Message)> RejectAppointmentByDoctorAsync(int id);
        Task<(bool Success, string? Message)> ApproveAppointmentByDoctorAsync(int id);
        Task<(bool Success, string? Message)> CancelAppointmentAsync(int id);



    }
}
