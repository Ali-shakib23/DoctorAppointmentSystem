using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using Humanizer;
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

        [HttpGet("{id}")]
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


        [HttpGet("{doctorName}", Name = "Get-Doctor-By-Name")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorByName(string doctorName)
        {
            var reviews = await _doctorService.SearchDoctorsByNameAsync(doctorName);

            if (reviews == null)
            {
                return Problem("not found");
            }
            return Ok(reviews);
        }

        //update doctor
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctorAsync(int id , [FromBody] DoctorDTO doctorDTO)
        {
            var result = await _doctorService.UpdateDoctorAsync(id, doctorDTO);

            if (!result)
            {
                return NotFound(new { success = false, message = "not updated." });
            }
            var updatedDoctor = await _doctorService.GetDoctorByIdAsync(id);

            return Ok(new { success = true, message = "Updated successfully." , updatedDoctor });
        }
        //delete doctor
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctorAsync(int id)
        {
            var result = await _doctorService.DeleteDoctorAsync(id);
            if (!result)
            {
                return NotFound(new { success = false, message = "not deleted." });
            }
            return Ok(new { success = true, message = "Doctor deleted successfully" });
        }
        //add
    }
}
