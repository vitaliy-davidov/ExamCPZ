using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.DAL.Interfaces
{
    public interface ICRUDRepository<T>
    {
        Task<T> CreateOrUpdateAsync(T item);
        T Delete(int id);
        ICollection<T> GetAll();
        T GetById(int id);
        Task<int> SaveChangesAsync();
    }
}
