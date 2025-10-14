using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.Infrastructure
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseTask
    {
        private static List<T> _taskList;
        public List<T> TaskList { get { return _taskList; } }

        public InMemoryRepository()
        {
            _taskList = new List<T>();
        }

        public void AddTask(T item)
        {
            _taskList.Add(item);
        }

        public void AddSubstask(Guid idTask, T item)
        {
            var selectedTask = GetTaskById(idTask);
            selectedTask.Subtask.Add(item);
        }

        public T? GetTaskById(Guid id)
        {
            var requestTask = _taskList.FirstOrDefault(x => x.Id == id);
            if (requestTask != null)
            {
                return requestTask;
            }
            else
            {
                return default;
            }
        }

        public List<T> GetAllTasks()
        {
            return _taskList;
        }

        public void RemoveTask(Guid id)
        {
            var taskToRemove = _taskList.FirstOrDefault(t => t.Id ==  id);
            if (taskToRemove != null)
            {
                _taskList.Remove(taskToRemove);
            }
        }

        public void CleanList()
        {
            _taskList.Clear();
        }

        public void CleanSubstaskList(Guid id) 
        {
            var SearchTask = _taskList.FirstOrDefault(item => item is BaseTask task && task.Id == id);
            if(SearchTask is BaseTask task)
            {
                task.Subtask.Clear();
            }
        }
    }
}
