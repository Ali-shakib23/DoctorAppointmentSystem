using DoctorAppointment.Core.DTOs;
using DoctorAppointment.Core.ServiceContracts;
using DoctorAppointment.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IReviewService _reviewService;
        public UserController(IDoctorService doctorService, IAppointmentService appointmentService, IReviewService reviewService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _reviewService = reviewService;

        }


        

    } 
}
