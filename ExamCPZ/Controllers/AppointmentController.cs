using AutoMapper;
using ExamCPZ.BLL.Interfaces;
using ExamCPZ.BLL.Models;
using ExamCPZ.BLL.Services;
using ExamCPZ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamCPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {

        private readonly ICRUDService<AppointmentModel> _appointmentService;
        private readonly ICRUDService<PatientModel> _patientService;

        public AppointmentController(ICRUDService<AppointmentModel> appointmentService, ICRUDService<PatientModel> patientService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        [HttpGet("all")]
        public ICollection<AppointmentModel> GetAll()
        {
            return _appointmentService.GetAll();
        }

        [HttpGet("{id}")]
        public AppointmentModel GetById(int id)
        {

            return _appointmentService.GetById(id);
        }

        [HttpPost("create")]
        public async Task<AppointmentModel> Create([FromBody] AppointmentViewModel model)
        {
            var appointment = new AppointmentModel() { Id = model.Id, Date = model.Date };
            appointment.Patient = new PatientModel() { Id = model.PatientId };

            return await _appointmentService.CreateOrUpdateAsync(appointment);
        }

        [HttpPost("edit/{id}")]
        public async Task<AppointmentModel> Update([FromRoute] int id, [FromBody] AppointmentViewModel model)
        {
            var appointment = new AppointmentModel() { Id=model.Id, Date = model.Date };
            appointment.Patient = _patientService.GetById(model.PatientId);
            appointment.Id = id;
            return await _appointmentService.CreateOrUpdateAsync(appointment);
        }

        [HttpDelete("delete/{id}")]
        public AppointmentModel Delete(int id)
        {
            return _appointmentService.Remove(id);
        }
    }
}
