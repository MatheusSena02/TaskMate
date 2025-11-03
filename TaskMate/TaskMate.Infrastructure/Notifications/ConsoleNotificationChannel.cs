using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Interfaces;

namespace TaskMate.Infrastructure.Notifications
{
    public class ConsoleNotificationChannel : INotificationChannel
    {
        public void SendCompletedTask(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tarefa \"{title}\" marcada como concluída!");
            Console.ResetColor();
        }
    }
}
