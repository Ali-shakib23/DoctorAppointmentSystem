using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IGenericRepository<User> _genericUserRepository;
        private readonly IGenericRepository<Doctor> _genericDoctorRepository;
        //private readonly IGenericRepository<Appointment> _genericRepository;
        public ReviewService(IReviewRepository reviewRepository, IGenericRepository<User> genericUserRepository,
             IGenericRepository<Doctor> genericDoctorRepository)
        {
            _reviewRepository = reviewRepository;
            _genericUserRepository = genericUserRepository;
            _genericDoctorRepository = genericDoctorRepository; 

        }
        public async Task<List<ReviewDTO>> GetDoctorReviewsAsync(int doctorID)
        {
            var reviews = await _reviewRepository.GetDoctorReviewsAsync(doctorID);

            List<ReviewDTO> reviewDTO = reviews.Select(x => new ReviewDTO
            {
                Id = x.ID,
                UserName = x.User.FullName,
                CreatedAt = DateTime.UtcNow,
                Comment = x.Comment,
                DoctorName = x.Doctor.FullName,

            }).ToList();

            return reviewDTO;

        }

        //add review
        public async Task<ReviewDTO> AddReviewByUserAsync(ReviewDTO ReviewDTO)
        {
            Review review = new Review()
            {
                Comment = ReviewDTO.Comment,
                Rating = ReviewDTO.Rating,
                UserID = ReviewDTO.UserId,
                DoctorID = ReviewDTO.DoctorId,
                CreatedAt = DateTime.UtcNow,
            };

            if (await _reviewRepository.AddAsync(review))
            {
               return await GetUserReviewAsync(review.ID);
            }
            return null;

        }

        public async Task<ReviewDTO> GetUserReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetUserReview(reviewId);

            if (review == null)
                return null;

            var reviewDto = new ReviewDTO
            {
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                Rating = review.Rating,
                DoctorName = review.Doctor.FullName,
                UserName = review.User.FullName
            };

            return reviewDto;
        }
        //delete review (by admin)
        public async Task<bool> DeleteReviewAsync(int doctorId)
        {
            return await _reviewRepository.DeleteAsync(doctorId);
        }
    }
}
