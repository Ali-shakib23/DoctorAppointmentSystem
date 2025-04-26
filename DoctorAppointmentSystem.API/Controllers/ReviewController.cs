using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("reviews/{doctorId}", Name = "GetDoctorReviews")]
        public async Task<ActionResult> GetDoctorReviewsAsync(int doctorId)
        {
            var reviews = await _reviewService.GetDoctorReviewsAsync(doctorId);

            if (reviews == null)
            {
                return NotFound(new { success = false, message = "No reivew found." });
            }
            return Ok(new { success = true, reviews });
        }

        [HttpGet("reviews/{Id}", Name = "GetUserReview")]
        public async Task<ActionResult> GetUserReviewAsync(int Id)
        {
            var review = await _reviewService.GetUserReviewAsync(Id);

            if (review == null)
            {
                return NotFound(new { success = false, message = "No reivew found." });
            }
            return Ok(new { success = true, review });
        }

        [HttpPost]
        public async Task<ActionResult> AddReviewByUserAsync([FromBody] ReviewDTO reviewDTO)
        {
            var review = await _reviewService.AddReviewByUserAsync(reviewDTO);

            if (review == null)
            {
                return NotFound(new { success = false, message = "Failed to create the appointment." });

            }
            return CreatedAtAction(nameof(GetUserReviewAsync), new { id = review.Id }, new { success = true, review });


        }
        [HttpPut]
        public async Task<ActionResult> EditReviewAsync(int id , ReviewDTO reviewDTO)
        {
            var result = await _reviewService.UpdateReviewAsync(id, reviewDTO);

            if (!result)
            {
                return NotFound(new { success = false, message = "Review not found." });
            }
            return Ok(new { success = true, message = "Review updated successfully." });
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteReviewAsync(int Id)
        {
            var result = await _reviewService.DeleteReviewAsync(Id);

            if (!result)
            {
                return NotFound(new { success = false, message = "Review not found." });
            }

            return Ok(new { success = true, message = "Review deleted successfully." });

        }

        

        

    }
}
