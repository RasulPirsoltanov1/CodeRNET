using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class,new()
    {
        void Add(T t);
        void Delete(int id);
        void Update(T t);
        T Get(int id);
        List<T> GetAll();
        void Dispose();

    }
}
