using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExamCPZ.DAL
{
    public class ExamCPZDBContextFactory : IDesignTimeDbContextFactory<ExamCPZDBContext>
    {
        public ExamCPZDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExamCPZDBContext>();
            optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=ExamDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new ExamCPZDBContext(optionsBuilder.Options);
        }
    }
}