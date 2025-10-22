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
        public List<T> TaskList { get; set; } = new();
         
        public void AddTask(T task)
        {
            TaskList.Add(task);
        }

        public T GetTaskById(Guid id)
        {
            var requestTask = TaskList.FirstOrDefault(x => x.Id == id);
            if(requestTask == null)
            {
                throw new ArgumentException("Não foi possível encontrar uma tarefa correspondente ao ID informado");
            }
            return requestTask;
        }

        public List<T> GetAllTasks()
        {
            return TaskList;
        }

        public void RemoveTask(Guid id)
        {
            var taskToRemove = TaskList.FirstOrDefault(t  => t.Id == id);
            if(taskToRemove == null)
            {
                throw new ArgumentException("Não foi possível encontrar uma tarefa correspondente ao ID informado");
            }
            else
            {
                TaskList.Remove(taskToRemove);
            }
        }

        public void CleanList()
        {
            TaskList.Clear();
        }

        public void UpdateTask(T task, Guid id)
        {
            var searchTask = TaskList.FirstOrDefault(task => task.Id == id);
            var indexSarchTask = TaskList.IndexOf(searchTask);
            if(indexSarchTask == -1)
            {
                TaskList[indexSarchTask] = task;
            }
        }
    }
}
