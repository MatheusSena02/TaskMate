using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Interfaces
{
    public interface INotificationChannel
    {
        string Send(string message);
    }
}
