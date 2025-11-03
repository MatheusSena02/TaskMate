using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Event;
using TaskMate.Core.Interfaces;

namespace TaskMate.Core.Operation
{
    public class TaskService
    {
        private readonly IRepository<BaseTask> _repository;
        private readonly INotificationChannel _notificationChannel;
        private readonly INotificationRepository _notificationRepository;
        private static bool _eventRegistered = false;
        public TaskService(IRepository<BaseTask> repository, INotificationChannel notificationChannel, INotificationRepository notificationRepository)
        {
            _repository = repository;
            _notificationChannel = notificationChannel;
            _notificationRepository = notificationRepository;
            if(!_eventRegistered)
            {
                TaskCompleted.OnCompleted += (task) =>
                {
                    MarkAsCompleted(task);
                };
                _eventRegistered = true;
            }
        }

        public void UpdateTitle(Guid IdTask, string newTitle)
        {
            var searchTask = _repository.GetTaskById(IdTask);
            if(searchTask != null)
            {
                if (!string.IsNullOrEmpty(newTitle))
                {
                    searchTask.Title = newTitle;
                    _repository.UpdateTask(searchTask);
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
                    _repository.UpdateTask(searchTask);
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
                        _repository.UpdateTask(searchTask);
                    }
                    else
                    {
                        throw new ArgumentException($"Formato inserido é inválido para o campo {nameof(searchTask.StartingDate)}");

                    }
                }
            }
        }

        public void AddSubstask(Guid IdMain, Subtask newSubstask)
        {
            if(newSubstask == null)
            {
                return;
            }

            var mainTask = _repository.GetTaskById(IdMain);
            if(mainTask == null)
            {
                return;
            }

            mainTask.SubtasksList.Add(newSubstask);
            _repository.UpdateTask(mainTask);
        }

        public void RemoveSubstask(Guid IdMain, Guid substaskToRemove)
        {
            var mainTask = _repository.GetTaskById(IdMain);
            if(mainTask == null)
            {
                return;
            }

            mainTask.SubtasksList.RemoveAll(x => x.Id == substaskToRemove);
            _repository.UpdateTask(mainTask);
        }

        public Subtask? GetSubtaskById(string IdMain, string IdSubtask)
        {
            if(!Guid.TryParse(IdSubtask, out Guid isValidTaskId) || string.IsNullOrEmpty(IdSubtask) || !Guid.TryParse(IdSubtask, out Guid isValidSubtaskId))
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

        public void MarkAsCompleted(BaseTask task)
        {
            if(task.TaskStatus == StatusOption.CONCLUIDA)
            {
                return;
            }
            task.MarkAsComplete();
            _repository.UpdateTask(task);
            _notificationChannel.SendCompletedTask(task.Title);
            _notificationRepository.AddNotification(task);
        }
    }
}
