using AutoMapper;
using ExamCPZ.BLL.Interfaces;
using ExamCPZ.BLL.Models;
using ExamCPZ.DAL.Entities;
using ExamCPZ.DAL.Interfaces;

namespace ExamCPZ.BLL.Services
{
    public class AppointmentService : ICRUDService<AppointmentModel>
    {
        private readonly ICRUDRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(ICRUDRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentModel> CreateOrUpdateAsync(AppointmentModel model)
        {
            var res = _mapper.Map<AppointmentModel>(await _appointmentRepository.CreateOrUpdateAsync(_mapper.Map<Appointment>(model)));
            await _appointmentRepository.SaveChangesAsync();
            return res;
        }

        public ICollection<AppointmentModel> GetAll()
        {
            return _mapper.Map<ICollection<AppointmentModel>>(_appointmentRepository.GetAll());
        }

        public AppointmentModel GetById(int id)
        {
            return _mapper.Map<AppointmentModel>(_appointmentRepository.GetById(id));
        }

        public AppointmentModel Remove(int id)
        {
            var res = _mapper.Map<AppointmentModel>(_appointmentRepository.Delete(id));
            _appointmentRepository.SaveChangesAsync();
            return res;
        }
    }
}
