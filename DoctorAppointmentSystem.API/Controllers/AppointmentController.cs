using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DoctorAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Gets a list of appointments for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user to fetch appointments for.</param>
        /// <returns>List of appointments associated with the user.</returns>
        [HttpGet("user/{userId}/appointments")]
        public async Task<ActionResult> GetUserAppointmentsAsync(int userId)
        {
            var appointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId);
            if (appointments == null || !appointments.Any())
            {
                return NotFound(new { success = false, message = "No appointments found for the user." });
            }
            return Ok(new { success = true, appointments });
        }

        /// <summary>
        /// Gets a list of appointments for a specific user.
        /// </summary>
        /// <param name="doctorId">The ID of the user to fetch appointments for.</param>
        /// <returns>List of appointments associated with the user.</returns>
        [HttpGet("doctor/{doctorId}/appointments")]
        public async Task<ActionResult> GetDoctorAppointmentsAsync(int doctorId)
        {
            var appointments = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            if (appointments == null || !appointments.Any())
            {
                return NotFound(new { success = false, message = "No appointments found for the user." });
            }
            return Ok(new { success = true, appointments });
        }

        /// <summary>
        /// Gets details of a specific appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment.</param>
        /// <returns>The details of the requested appointment.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound(new { success = false, message = "No appointment found with the provided ID." });
            }
            return Ok(new { success = true, appointment });
        }

        /// <summary>
        /// Books a new appointment for a user.
        /// </summary>
        /// <param name="appointmentDTO">The details of the appointment to be booked.</param>
        /// <returns>The created appointment or an error message.</returns>
        [HttpPost]
        public async Task<ActionResult> BookAppointmentAsync(CreateAppointmentDTO appointmentDTO)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(appointmentDTO);

            if (appointment == null)
            {
                return NotFound(new { success = false, message = "Failed to create the appointment." });
            }

            return CreatedAtAction(nameof(GetAppointmentByIdAsync), new { id = appointment.Id }, new { success = true, appointment });
        }

        /// <summary>
        /// Approves an appointment by the doctor.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to approve.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpPut("{appointmentId}/approve")]
        public async Task<ActionResult> ApproveAppointmentAsync(int appointmentId)
        {
            var result = await _appointmentService.ApproveAppointmentByDoctorAsync(appointmentId);
            if (result.Success)
            {
                return Ok(new { success = true, message = "Appointment approved successfully." });
            }
            return BadRequest(new { success = false, message = result.Message });
        }


        /// <summary>
        /// Updates an existing appointment.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to update.</param>
        /// <param name="appointmentDTO">The updated appointment data.</param>
        /// <returns>ActionResult with the update status.</returns>
        [HttpPut("{appointmentId}")]
        public async Task<ActionResult> UpdateAppointmentAsync(int appointmentId, [FromBody] AppointmentDTO appointmentDTO)
        {
            var result = await _appointmentService.UpdateAppointment(appointmentId, appointmentDTO);
            if (!result)
            {
                return BadRequest(new { success = false, message = "Failed to update appointment." });
            }
            return Ok(new { success = true, message = "Updated successfully" });
        }
        /// <summary>
        /// Rejects an appointment by the doctor.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to reject.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpPut("{appointmentId}/reject")]
        public async Task<ActionResult> RejectAppointmentAsync(int appointmentId)
        {
            var result = await _appointmentService.RejectAppointmentByDoctorAsync(appointmentId);
            if (result.Success)
            {
                return Ok(new { success = true, message = "Appointment rejected successfully." });
            }
            return BadRequest(new { success = false, message = result.Message });
        }

        /// <summary>
        /// Cancels an appointment.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to cancel.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpPut("{appointmentId}/cancel")]
        public async Task<ActionResult> CancelAppointmentAsync(int appointmentId)
        {
            var result = await _appointmentService.CancelAppointmentAsync(appointmentId);
            if (result.Success)
            {
                return Ok(new { success = true, message = "Appointment canceled successfully." });
            }
            return BadRequest(new { success = false, message = result.Message });
        }

        /// <summary>
        /// Deletes an appointment by ID.
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to delete.</param>
        /// <returns>ActionResult indicating the result of the delete operation.</returns>
        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult> DeleteAppointmentAsync(int appointmentId)
        {
            var result = await _appointmentService.DeleteAppointmentByAdminAsync(appointmentId);

            if (!result)
            {
                return NotFound(new { success = false, message = "Appointment not found or could not be deleted." });
            }

            return Ok(new { success = true, message = "Appointment deleted successfully." });
        }


    }
}
