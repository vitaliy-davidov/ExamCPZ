using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.BLL.Interfaces
{
    public interface ICRUDService<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        Task<T> CreateOrUpdateAsync(T model);
        T Remove(int id);
    }
}
