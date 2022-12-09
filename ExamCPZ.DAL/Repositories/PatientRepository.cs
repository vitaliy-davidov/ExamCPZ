using ExamCPZ.DAL.Entities;
using ExamCPZ.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.DAL.Repositories
{
    public class PatientRepository : ICRUDRepository<Patient>
    {
        private readonly ExamCPZDBContext _dbContext;

        public PatientRepository(ExamCPZDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient> CreateOrUpdateAsync(Patient item)
        {
            await _dbContext.SaveChangesAsync();
            Patient entity;
            if (item.Id == 0)
                entity = _dbContext.Patients.Add(item).Entity;
            else entity = _dbContext.Patients.Update(item).Entity;
            return entity;
        }

        public Patient Delete(int id)
        {
            var patient = _dbContext.Patients.FirstOrDefault(c => c.Id == id);
            if (patient != null)
                return _dbContext.Patients.Remove(patient).Entity;
            return null;
        }

        public ICollection<Patient> GetAll()
        {
            return _dbContext.Patients.AsEnumerable().ToList();
        }

        public Patient GetById(int id)
        {
            return _dbContext.Patients.Find(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
