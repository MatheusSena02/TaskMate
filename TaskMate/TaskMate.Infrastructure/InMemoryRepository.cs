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
            var requestTask = _taskList.FirstOrDefault(item => item is Base task && task.Id == id);
            if(requestTask != null)
            {
                return requestTask;
            }
            else
            {
                return null;
            }
        }

        public List<T> GetAll()
        {
            return _taskList;
        }

        public void Remove(Guid id)
        {
            var taskToRemove = GetById(id);
            if(taskToRemove != null)
            {
                _taskList.Remove(taskToRemove);
            }
        }

        public void Clean()
        {
            _taskList.Clear();
        }

    }
}
