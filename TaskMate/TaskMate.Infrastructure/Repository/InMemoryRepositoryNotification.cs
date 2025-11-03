using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Interfaces;

namespace TaskMate.Infrastructure.Repository
{
    public class InMemoryRepositoryNotification : INotificationRepository
    {
        public List<string> NotificationList { get; set; } = new();

        public void AddNotification(BaseTask task)
        {
            NotificationList.Add($"[{DateTime.Now}] Tarefa \"{task.Title}\" marcada como concluída!");
        }

        public List<string> GetAllNotifications()
        {
            return NotificationList;
        }
    }
}
