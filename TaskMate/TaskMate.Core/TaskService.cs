using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    internal class TaskService
    {
        private readonly IRepository<BaseTask> _repository;

        public TaskService(IRepository<BaseTask> repository)
        {
            _repository = repository;
            TaskMate
        }

        public void UpdateTitle(string newTitle, Guid id)
        {
            var searchTask = _repository.GetTaskById(id);
            if (!String.IsNullOrEmpty(newTitle) && searchTask != null)
            {
                searchTask.Title = newTitle;
            }
        }

        public void UpdateDescription(string newDescription, Guid id)
        {
            var searchTask = _repository.GetTaskById(id);
            if (!String.IsNullOrEmpty(newDescription) && searchTask != null)
            {
                searchTask.Description = newDescription;
            }
        }

        public void UpdateStartingDate(string newStartingDate, Guid id)
        {
            var searchTask = _repository.GetTaskById(id);
            if (!String.IsNullOrEmpty(newStartingDate) && searchTask != null)
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
}
