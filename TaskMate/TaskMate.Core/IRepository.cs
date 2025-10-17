using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public interface IRepository<T> where T : BaseTask
    {
        T? GetTaskById(Guid id);
        List<T> GetAllTasks();
        void AddTask(T item);
        void RemoveTask(Guid id);
        void CleanList();
    }
}
