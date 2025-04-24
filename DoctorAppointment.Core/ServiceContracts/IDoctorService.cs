using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.ServiceContracts
{
    public interface IDoctorService
    {
        Task<DoctorDTO> GetDoctorByIdAsync(int id);
        Task<List<DoctorDTO>> SearchDoctorsByNameAsync(string name);

        Task<List<DoctorDTO>> GetAllDoctors();
        Task<List<DoctorDTO>> SearchDoctorBySpecilalization(string specialization);
        Task<List<Schedule>> GetDoctorScheduleAsync(int doctorId);


        ////Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        
        
        Task<bool> AddDoctorAsync(DoctorDTO dto);
        Task<bool> UpdateDoctorAsync(int id,DoctorDTO dto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}
