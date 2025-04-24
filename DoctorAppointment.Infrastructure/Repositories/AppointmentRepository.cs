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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {

        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointments.Where(x => x.DoctorID == doctorId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(int userId)
        {
            return await _context.Appointments.Where(x => x.UserID == userId).ToListAsync();
        }

        public async Task<Appointment> GetByIdWithUserAndDoctorAsync(int appointmentId)
        {
            return await _context.Appointments.Include(x => x.User)
                                          .Include(x => x.Doctor)
                                          .FirstOrDefaultAsync(x => x.ID == appointmentId);
        }

        //public async Task<>
    }
}
