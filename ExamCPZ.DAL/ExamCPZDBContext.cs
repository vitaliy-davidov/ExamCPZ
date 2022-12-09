using ExamCPZ.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExamCPZ.DAL
{
    public class ExamCPZDBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public ExamCPZDBContext(DbContextOptions<ExamCPZDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}