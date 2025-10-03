using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.Infrastructure
{
    public class InMemoryRepository <T> : IRepository<T>
    {
        private List<T> _taskList;
        public List<T> TaskList { get { return _taskList; } }   
        public InMemoryRepository()
        {
            _taskList = new List<T>();
        }
        public void Add(T item)
        {
            _taskList.Add(item);
        }

        public T GetById(Guid id)
        {

            return _taskList.FirstOrDefault(item => item is BaseTask task && task.Id == id);
        }
    }
}
