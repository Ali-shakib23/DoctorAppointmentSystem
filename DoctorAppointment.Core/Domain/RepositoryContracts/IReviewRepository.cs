using DoctorAppointment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.RepositoryContracts
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<List<Review>> GetDoctorReviewsAsync(int doctorID);
        Task<Review> GetUserReview(int reviewId);
        Task<Appointment> GetByIdWithUserAndDoctorAsync(int appointmentId);
    }
}
