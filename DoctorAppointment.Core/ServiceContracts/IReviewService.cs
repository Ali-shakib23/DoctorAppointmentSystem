using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.ServiceContracts
{
    public interface IReviewService
    {
     
        Task<ReviewDTO> GetUserReviewAsync(int reviewId);
        Task<ReviewDTO> AddReviewByUserAsync(ReviewDTO ReviewDTO);

        Task<List<ReviewDTO>> GetDoctorReviewsAsync(int doctorID);

        Task<bool> DeleteReviewAsync(int doctorId);
        Task<bool> UpdateReviewAsync(int id, ReviewDTO reviewDTO);
    }
}
