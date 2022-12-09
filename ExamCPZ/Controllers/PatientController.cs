using ExamCPZ.BLL.Interfaces;
using ExamCPZ.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamCPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {

        private readonly ICRUDService<PatientModel> _patientService;

        public PatientController(ICRUDService<PatientModel> patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("all")]
        public ICollection<PatientModel> GetAll()
        {
            return _patientService.GetAll();
        }

        [HttpGet("{id}")]
        public PatientModel GetById(int id)
        {

            return _patientService.GetById(id);
        }

        [HttpPost("create")]
        public async Task<PatientModel> Create([FromBody] PatientModel model)
        {
            return await _patientService.CreateOrUpdateAsync(model);
        }

        [HttpPost("edit/{id}")]
        public async Task<PatientModel> Update([FromRoute] int id, [FromBody] PatientModel model)
        {
            model.Id = id;
            return await _patientService.CreateOrUpdateAsync(model);
        }

        [HttpDelete("delete/{id}")]
        public PatientModel Delete(int id)
        {
            return _patientService.Remove(id);
        }
    }
}
