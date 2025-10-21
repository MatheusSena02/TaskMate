using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class DeadLineTask : BaseTask
    {
        public DateOnly DeadLineDate { get; set; }

        public DeadLineTask(string title, string startingDate, string deadLineDate, string description = "") : base(title, startingDate, description)
        {
            if(ValidateDate(deadLineDate) < ValidateDate(startingDate))
            {
                throw new ArgumentException("Lógica inválida: A data de término não pode ser anterior a data de início");
            }

            this.DeadLineDate = ValidateDate(ValidateAndSet(deadLineDate);

            if (DeadLineDate < DateOnly.FromDateTime(DateTime.Now))
            {
                this.TaskStatus = StatusOption.ATRASADA;
            }
            else
            {
                this.TaskStatus = StatusOption.NAO_INICIADA;
            }

        }

        public void SetStartTask()
        {
            this.TaskStatus = StatusOption.EM_PROGRESSO;
        }
        
        public void UpdateDeadLineDate(string newDeadLineDate)
        {
            if(!String.IsNullOrEmpty(newDeadLineDate))
            {
                this.DeadLineDate = ValidateDate(newDeadLineDate);
            }
        }
    }
}
