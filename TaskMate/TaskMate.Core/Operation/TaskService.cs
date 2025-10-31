using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Interfaces;

namespace TaskMate.Core.Operation
{
    public class TaskService
    {
        private readonly IRepository<BaseTask> _repository;
        public TaskService(IRepository<BaseTask> repository)
        {
            _repository = repository;
        }

        public void UpdateTitle(Guid IdTask, string newTitle)
        {
            var searchTask = _repository.GetTaskById(IdTask);
            if(searchTask != null)
            {
                if (!string.IsNullOrEmpty(newTitle))
                {
                    searchTask.Title = newTitle;
                }
            }
        }

        public void UpdateDescription(Guid IdTask, string newDescription)
        {
            var searchTask = _repository.GetTaskById(IdTask);
            if(searchTask != null)
            {
                if (!string.IsNullOrEmpty(newDescription))
                {
                    searchTask.Description = newDescription;
                }
            }
        }

        public void UpdateStartingDate(Guid IdMain, string newStartingDate)
        {
            var searchTask = _repository.GetTaskById(IdMain);
            if(searchTask != null)
            {
                if (!string.IsNullOrEmpty(newStartingDate))
                {
                    var validateStartingDate = DateOnly.TryParseExact(BaseTask.ValidateAndSet(newStartingDate), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidStartingDate);
                    if (validateStartingDate == true)
                    {
                        searchTask.StartingDate = isValidStartingDate;
                    }
                    else
                    {
                        throw new ArgumentException($"Formato inserido é inválido para o campo {nameof(searchTask.StartingDate)}");

                    }
                }
            }
        }

        public void AddSubstask(string IdMain, Subtask newSubstask)
        {
            if(!Guid.TryParse(IdMain, out Guid isValidId) || newSubstask == null)
            {
                return;
            }

            var mainTask = _repository.GetTaskById(isValidId);
            if(mainTask == null)
            {
                return;
            }

            mainTask.SubtasksList.Add(newSubstask);
        }

        public void RemoveSubstask(string IdMain, string substaskToRemove)
        {
            if(!Guid.TryParse(IdMain, out Guid isValidTaskId) || !Guid.TryParse(substaskToRemove, out Guid isValidSubstaskId))
            {
                throw new ArgumentException("Falha na formatação : Os campos de Id não podem ser convertidos para Id válidos");
            }

            var mainTask = _repository.GetTaskById(isValidTaskId);
            if(mainTask == null)
            {
                return;
            }

            mainTask.SubtasksList.RemoveAll(x => x.Id == isValidSubstaskId);
        }

        public Subtask? GetSubtaskById(string IdMain, string IdSubtask)
        {
            if(!Guid.TryParse(IdSubtask, out Guid isValidTaskId) || string.IsNullOrEmpty(IdSubtask) || !Guid.TryParse(IdSubtask, out Guid isValidSubtaskId)
            {
                return null;
            }
            
            var mainTask = _repository.GetTaskById(isValidTaskId);
            if(mainTask == null)
            {
                return null;
            }

            return mainTask.SubtasksList.FirstOrDefault(s => s.Id == isValidSubtaskId);
        }
    }
}
