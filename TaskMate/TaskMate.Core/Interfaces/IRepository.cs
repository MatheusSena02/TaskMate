using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;

namespace TaskMate.Core.Interfaces
{
    public interface IRepository<T> where T : BaseTask
    {
        T? GetTaskById(Guid id);
        List<T> GetAllTasks();
        void AddTask(T item);
        void RemoveTask(Guid id);
        void CleanList();
        void UpdateTask(T task);
    }
}
