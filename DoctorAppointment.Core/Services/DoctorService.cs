using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository, 
            IGenericRepository<Doctor> genericDoctorReposiotry)
        {
            _doctorRepository = doctorRepository;
            
        }

        public async Task<bool> AddDoctorAsync(DoctorDTO dto)
        {
            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Position = dto.Position,
                Degree = dto.Degree,
                Qualifications = dto.Qualifications,
                SpecializationId = dto.SpecializationId,
                ExperienceYears = dto.ExperienceYears,
                Rating = 0,
            };

            return await _doctorRepository.AddAsync(doctor);
 
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            return await _doctorRepository.DeleteAsync(id);
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if(doctor != null)
            {
                DoctorDTO doctorDTO = new DoctorDTO
                {

                    FullName = doctor.FullName,
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Position = doctor.Position,
                    Degree = doctor.Degree,
                    Qualifications = doctor.Qualifications,
                    SpecializationId = doctor.SpecializationId,
                    ExperienceYears = doctor.ExperienceYears,
                    Rating = doctor.Rating,

                };
                return doctorDTO;
            }
            return null;

        }

        public Task<List<Schedule>> GetDoctorScheduleAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DoctorDTO>> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            List<DoctorDTO> doctorDTOs = doctors.Select(d => new DoctorDTO
            {
                FullName = d.FullName,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber,
                Position = d.Position,
                Degree = d.Degree,
                Qualifications = d.Qualifications,
                SpecializationId = d.SpecializationId,
                ExperienceYears = d.ExperienceYears,
                Rating = d.Rating,

            }).ToList();
            return doctorDTOs;
        }
        

        public async Task<List<DoctorDTO>> SearchDoctorBySpecilalization(string specialization)
        {
          var doctors = await _doctorRepository.GetDoctorsListsBySpecializationAsync(specialization);
          List <DoctorDTO> doctorDTO = doctors.Select(d => new DoctorDTO
          {
                FullName = d.FullName,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber,
                Position = d.Position,
                Degree = d.Degree,
                Qualifications = d.Qualifications,
                SpecializationId = d.SpecializationId,
                ExperienceYears = d.ExperienceYears,
                Rating = d.Rating,

            }).ToList();

          return doctorDTO;
        }

        public async Task<List<DoctorDTO>> SearchDoctorsByNameAsync(string name)
        {
            var doctors = await _doctorRepository.GetDoctorByName(name);
            List<DoctorDTO> doctorDTO = doctors.Select(d => new DoctorDTO
            {
                FullName = d.FullName,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber,
                Position = d.Position,
                Degree = d.Degree,
                Qualifications = d.Qualifications,
                SpecializationId = d.SpecializationId,
                ExperienceYears = d.ExperienceYears,
                Rating = d.Rating,

            }).ToList();
            return doctorDTO;
        }

        public async Task<bool> UpdateDoctorAsync(int id, DoctorDTO dto)
        {
            var doctor =await  _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return false;
            }
            doctor.FullName = dto.FullName;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.Email = dto.Email;
            doctor.PhoneNumber = dto.PhoneNumber;
            doctor.Qualifications = dto.Qualifications;
            doctor.SpecializationId = dto.SpecializationId;
            doctor.Rating = dto.Rating;
            doctor.Position = dto.Position;

            return await _doctorRepository.UpdateAsync(doctor);
            
           
            
        }
       

        
    }
}
