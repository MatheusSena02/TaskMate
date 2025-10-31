using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Core
{
    public class Subtask
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateOnly StartingDate { get; set; }
        public StatusOption TaskStatus { get; set; } 

        public Subtask(string title, string startingDate, string description = "")
        {
            this.Title = BaseTask.ValidateAndSet(title);
            this.StartingDate = BaseTask.ValidateDate(BaseTask.ValidateAndSet(startingDate));
            this.Description = description;
            this.TaskStatus = StatusOption.NAO_INICIADA;
        }

        public void MarkAsCompleted()
        {
            this.TaskStatus = StatusOption.CONCLUIDA;
        }

    }
}
