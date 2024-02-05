using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IService<T> where T : class, new()
    {
        void Add(T t);
        void Delete(int id);
        void Update(T t);
        T Get(int id);
        List<T> GetAll();
    }
}
