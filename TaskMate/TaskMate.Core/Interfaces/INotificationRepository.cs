using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;

namespace TaskMate.Core.Interfaces
{
    public interface INotificationRepository
    {
        void AddNotification(BaseTask task);
        List<string> GetAllNotifications();
    }
}
