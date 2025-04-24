using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetDoctorByName(string doctorName)
        {
            return await _context.Doctors.Where(x => EF.Functions.Like(x.FullName, $"%{doctorName}%"))
                                         .ToListAsync();
           
        }

        //public async Task<List<Doctor>> GetDoctorByID(int Doctr)
       
        // Implement domain-specific methods
    
        public async Task<IEnumerable<Doctor>> GetDoctorsListsBySpecializationAsync(string specializationName)
        {
            return await _context.Doctors
                               .Where(x => EF.Functions.Like(x.Specialization.Name, $"%{specializationName}%"))
                               .ToListAsync();
        }




        public async Task<Doctor> GetDoctorWithAppointmentsAsync(int doctorId)
        {
            return await _context.Doctors
                                 .Include(d => d.Appointments)
                                 .FirstOrDefaultAsync(d => d.ID == doctorId);
        }
    }

}
