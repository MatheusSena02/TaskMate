using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class DeadLineTask : BaseTask
    {
        private DateOnly _deadLineDate;
        public DateOnly DeadLineDate => _deadLineDate;

        public DeadLineTask(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "") : base(title, startingDate, description)
        {
            if(deadLineDate < startingDate)
            {
                throw new ArgumentException("Invalid date range: End date precedes start date");
            }
            if(deadLineDate < DateOnly.FromDateTime(DateTime.Now)){
                this.TaskStatus = statusOption.ATRASADA;
            }
            else
            {
                this.TaskStatus = statusOption.NAO_INICIADA;
            }
                this._deadLineDate = deadLineDate;
            
        }

        public void SetStartTask()
        {
            this.TaskStatus = statusOption.EM_PROGRESSO;
        }

        public void UpdateDeadLineDate(string newDeadLineDate)
        {
            var newDeadLineDateFormatted = DateOnly.Parse(newDeadLineDate);
            if(!String.IsNullOrEmpty(newDeadLineDate))
            {
                this._deadLineDate = newDeadLineDateFormatted;
            }
            
            if(TaskStatus == statusOption.ATRASADA && newDeadLineDateFormatted > DateOnly.FromDateTime(DateTime.Now))
            {
                TaskStatus = statusOption.NAO_INICIADA;
            }else if (TaskStatus == statusOption.EM_PROGRESSO && newDeadLineDateFormatted > DateOnly.FromDateTime(DateTime.Now))
            {
                TaskStatus = statusOption.EM_PROGRESSO;
            }
        }

        public override void PrintTask()
        {
            if (TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}\n\t- (Prazo: {DeadLineDate})");
            }
            else
            {
                Console.WriteLine($"[ID: {Id}]\n[X] {Title}\n\t- Descrição: {Description}\n\t- (Prazo: {DeadLineDate})");
            }
        }
    }
}
