using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IReviewService _reviewService;
        public DoctorController(IDoctorService doctorService, IAppointmentService appointmentService, IReviewService reviewService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _reviewService = reviewService;

        }
        [HttpGet("doctors")]
        public async Task<ActionResult<List<DoctorDTO>>> GetAllDoctors()
        {
            List<DoctorDTO> doctors = await _doctorService.GetAllDoctors();

            if (doctors == null)
            {
                return NotFound("not found");
            }
            return Ok(doctors);
        }

        [HttpGet("doctors/{id}")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorDetails(int id)
        {
            DoctorDTO doctorDTO = await _doctorService.GetDoctorByIdAsync(id);
            if (doctorDTO == null)
            {
                return NotFound("not found");
            }
            return Ok(doctorDTO);
        }

        [HttpGet("doctors/specialization/{specialization}")]
        public async Task<ActionResult<List<DoctorDTO>>> GetDoctorsBySpecialization(string specialization)
        {
            List<DoctorDTO> doctorDTO = await _doctorService.SearchDoctorBySpecilalization(specialization);
            if (doctorDTO == null)
            {
                return NotFound("no content");
            }
            return Ok(doctorDTO);
        }

        [HttpGet("reviews/{doctorID}", Name = "GetDoctorReviews")]
        public async Task<ActionResult> GetDoctorReviews(int doctorID)
        {
            var reviews = await _reviewService.GetDoctorReviews(doctorID);

            if (reviews == null)
            {
                return Problem("not found");
            }
            return Ok(reviews);

        }

        [HttpGet("Get-Doctor-By-Name")]
        public  async Task<ActionResult<DoctorDTO>> GetDoctorByName(string DoctorNmme)
        {
            var reviews = await _reviewService.GetDoctorByName(DoctorName);

            if (reviews == null)
            {
                return Problem("not found");
            }
            return Ok(reviews);
        }
    }
}
