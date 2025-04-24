using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Appointment> GetByIdWithUserAndDoctorAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Review>> GetDoctorReviewsAsync(int doctorID)
        {
            List<Review> reviews =await _context.Reviews.Where(x => x.DoctorID == doctorID).ToListAsync();

            return reviews;
        }

        public async Task<Review> GetUserReview(int reviewId)
        {
            return await _context.Reviews.Include(r => r.User)
                                          .Include(r => r.Doctor)
                                          .FirstOrDefaultAsync(r => r.ID == reviewId);
        }
    }
}
