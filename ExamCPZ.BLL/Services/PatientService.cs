using AutoMapper;
using ExamCPZ.BLL.Interfaces;
using ExamCPZ.BLL.Models;
using ExamCPZ.DAL.Entities;
using ExamCPZ.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.BLL.Services
{
    public class PatientService : ICRUDService<PatientModel>
    {
        private readonly ICRUDRepository<Patient> _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(ICRUDRepository<Patient> patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientModel> CreateOrUpdateAsync(PatientModel model)
        {
            var res = _mapper.Map<PatientModel>( await _patientRepository.CreateOrUpdateAsync(_mapper.Map<Patient>(model)));
            await _patientRepository.SaveChangesAsync();
            return res;
        }

        public ICollection<PatientModel> GetAll()
        {
            return _mapper.Map<ICollection<PatientModel>>(_patientRepository.GetAll());
        }

        public PatientModel GetById(int id)
        {
            var res = _mapper.Map<PatientModel>(_patientRepository.GetById(id));
            _patientRepository.SaveChangesAsync();
            return res;
        }

        public PatientModel Remove(int id)
        {
            var res = _mapper.Map<PatientModel>(_patientRepository.Delete(id));
            _patientRepository.SaveChangesAsync();
            return res;
        }
    }
}
