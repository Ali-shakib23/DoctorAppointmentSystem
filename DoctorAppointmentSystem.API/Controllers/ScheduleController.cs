using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody] ScheduleDTO scheduleDTO)
        {
            var createdSchedule = await _scheduleService.AddScheduleAsync(scheduleDTO);
            if (createdSchedule == null)
            {
                return BadRequest("Failed to create schedule.");
            }
            return Ok(createdSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleDTO scheduleDTO)
        {
            var updated = await _scheduleService.UpdateScheduleAsync(id, scheduleDTO);
            if (!updated)
            {
                return NotFound($"Schedule with ID {id} not found.");
            }
            return Ok("Schedule updated successfully.");
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorSchedule(int doctorId)
        {
            var schedules = await _scheduleService.GetDoctorScheduleAsync(doctorId);
            return Ok(schedules);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var deleted = await _scheduleService.DeleteScheduleAsync(id);
            if (!deleted)
            {
                return NotFound($"Schedule with ID {id} not found.");
            }
            return Ok("Schedule deleted successfully.");
        }

        [HttpPatch("{id}/availability")]
        public async Task<IActionResult> SetScheduleAvailability(int id, [FromQuery] bool isAvailable)
        {
            var updatedSchedule = await _scheduleService.SetScheduleAvailabilityAsync(id, isAvailable);
            if (updatedSchedule == null)
            {
                return NotFound($"Schedule with ID {id} not found.");
            }
            return Ok(updatedSchedule);
        }
    }
}

