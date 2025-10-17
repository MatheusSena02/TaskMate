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
         
        public void AddTask(T item)
        {
            TaskList.Add(item);
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
            var searchTask = _taskList.FirstOrDefault(a => a.Id == id);
            searchTask.Subtask.Clear();
        }

        public void EditTitle(Guid id, string newTitle)
        {
            if (!String.IsNullOrEmpty(newTitle))
            {
                var selectedTask = GetTaskById(id);
                if(selectedTask == null)
                {
                    throw new ArgumentException("Não foi impossível encontrar a tarefa. Verifique o Id e digite novamente");
                }
                else
                {
                    selectedTask.Title = newTitle;
                }
            }
        }

        public void EditDescription(Guid id, string newDescription)
        {
            if (!String.IsNullOrEmpty(newDescription))
            {
                var selectedTask = GetTaskById(id);
                if(selectedTask == null)
                {
                    throw new ArgumentException("Não foi impossível encontrar a tarefa. Verifique o Id e digite novamente");
                }else
                {
                    selectedTask.Description = newDescription;
                }
            }
        }

        public void EditStartingDate(Guid id, string newStartingDate)
        {
            if (!String.IsNullOrEmpty(newStartingDate))
            {
                var selectedTask = GetTaskById(id);
                if(selectedTask == null)
                {
                    throw new ArgumentException("Não foi impossível encontrar a tarefa. Verifique o Id e digite novamente");
                }
                else
                {
                    try
                    {
                        var formattedDate = DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidStartingDate);
                        if(formattedDate == true)
                        {
                            selectedTask.StartingDate = isValidStartingDate;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid date range: End date precedes start date");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    
                }
            }
        }
    }
}
