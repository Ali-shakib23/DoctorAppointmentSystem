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
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        private readonly ApplicationDbContext _context;
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> BulkUploadSchedulesAsync(IEnumerable<Schedule> schedules)
        {
            await _context.Schedules.AddRangeAsync(schedules);
            await _context.SaveChangesAsync();
            return schedules;
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByDoctorIdAsync(int doctorId)
        {
            return await _context.Schedules
                 .Where(s => s.DoctorID == doctorId)
                 .ToListAsync();
        }

        public async Task<bool> SetScheduleAvailabilityAsync(int id, bool isAvailable)
        {
            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(s => s.ID == id);

            if (schedule == null) return false;

            schedule.IsAvailable = isAvailable;
            await Save();
            return true;
        }
    }
}
