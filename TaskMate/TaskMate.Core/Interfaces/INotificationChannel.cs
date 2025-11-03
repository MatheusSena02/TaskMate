using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Interfaces
{
    public interface INotificationChannel
    {
        string Send(NotificationMessage message);
    }
    public class NotificationMessage
    {
        public string Recipient { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Body {  get; set; } = String.Empty;
    }
}
