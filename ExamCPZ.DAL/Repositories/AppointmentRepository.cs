using ExamCPZ.DAL.Entities;
using ExamCPZ.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamCPZ.DAL.Repositories
{
    public class AppointmentRepository : ICRUDRepository<Appointment>
    {
        private readonly ExamCPZDBContext _dbContext;

        public AppointmentRepository(ExamCPZDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Appointment> CreateOrUpdateAsync(Appointment item)
        {
            var patientId = item.Patient.Id;
            item.Patient = _dbContext.Patients.Include(p => p.Appointments).FirstOrDefault(p => p.Id == patientId);
            item.Patient.Appointments.Add(item);
            var entity = _dbContext.Appointments.Update(item).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Appointment Delete(int id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(c => c.Id == id);
            if (appointment != null)
                return _dbContext.Appointments.Remove(appointment).Entity;
            return null;
        }

        public ICollection<Appointment> GetAll()
        {
            return _dbContext.Appointments.Include(a => a.Patient).ToList();
        }

        public Appointment GetById(int id)
        {
            return _dbContext.Appointments.Include(a => a.Patient).FirstOrDefault(q => q.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
