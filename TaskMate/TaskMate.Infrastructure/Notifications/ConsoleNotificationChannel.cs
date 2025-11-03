using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Interfaces;

namespace TaskMate.Infrastructure.Notifications
{
    public class ConsoleNotificationChannel : INotificationChannel
    {
        public string Send(string message)
        {
            return message;
        }
    }
}
