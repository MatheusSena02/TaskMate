using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Interfaces;

namespace TaskMate.Core.Operation
{
    public class SubtaskService
    {
        private IRepository<BaseTask> _repository;

        public SubtaskService(IRepository<BaseTask> repository)
        {
            _repository = repository;
        }

        public void UpdateSubtask(string IdMain, Subtask subtask)
        {
            if (!Guid.TryParse(IdMain, out Guid isValidTaskId) || string.IsNullOrEmpty(IdMain) || subtask == null)
            {
                return;
            }

            var mainTask = _repository.GetTaskById(isValidTaskId);

            if (mainTask == null)
            {
                return;
            }

            for (int i = 0; i < mainTask.SubtasksList.Count; i++)
            {
                if (mainTask.SubtasksList[i].Id == subtask.Id)
                {
                    mainTask.SubtasksList[i] = subtask;
                    _repository.UpdateTask(mainTask);
                    break;
                }
            }
        }

        public void UpdateTitle(string IdMain, string IdSubtask, string newTitle)
        {
            if(!Guid.TryParse(IdMain, out Guid isValidTaskId) ||!Guid.TryParse(IdSubtask, out Guid isValidSubtaskId) || string.IsNullOrEmpty(newTitle))
            {
                return;
            } 

            var mainTask = _repository.GetTaskById(isValidTaskId);
            if(mainTask == null)
            {
                return;
            }

            var searchSubtask = mainTask.SubtasksList.FirstOrDefault(s => s.Id == isValidSubtaskId);
            if(searchSubtask == null)
            {
                return;
            }
            searchSubtask.Title = newTitle;
            UpdateSubtask(IdMain, searchSubtask);
        }

        public void UpdateDescription(string IdMain, string IdSubtask, string newDescription)
        {
            if (!Guid.TryParse(IdMain, out Guid isValidTaskId) || !Guid.TryParse(IdSubtask, out Guid isValidSubtaskId) || string.IsNullOrEmpty(newDescription))
            {
                return;
            }

            var mainTask = _repository.GetTaskById(isValidTaskId);
            if (mainTask == null)
            {
                return;
            }

            var searchSubtask = mainTask.SubtasksList.FirstOrDefault(s => s.Id == isValidSubtaskId);
            if (searchSubtask == null)
            {
                return;
            }
            searchSubtask.Description = newDescription;
            UpdateSubtask(IdMain, searchSubtask);
        }

        public void UpdateStartingDate(string IdMain, string IdSubtask, string newStartingDate)
        {
            if(!Guid.TryParse(IdMain, out Guid isValidTaskId) || !Guid.TryParse(IdSubtask, out Guid isValidSubtaskId) || !DateOnly.TryParseExact(newStartingDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidStartingDate))
            {
                return;
            }

            var mainTask = _repository.GetTaskById(isValidTaskId);
            
            if(mainTask == null)
            {
                return;
            }

            var searchSubtask = mainTask.SubtasksList.FirstOrDefault(s => s.Id == isValidSubtaskId);
            if(searchSubtask == null)
            {
                return;
            }
            searchSubtask.StartingDate = isValidStartingDate;
            UpdateSubtask(IdMain , searchSubtask);

        }
    }
}
