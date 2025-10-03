using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public interface IRepository<T>
    {
        T? GetById(Guid id);
        List<T> GetAll();
        void Add(T item);
        void Remove(Guid id);
        void Clean();
    }
}
