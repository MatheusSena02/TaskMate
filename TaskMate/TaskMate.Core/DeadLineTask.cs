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

        public DeadLineTask(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "") : base(title, startingDate, description)
        {
            if(deadLineDate < startingDate)
            {
                throw new ArgumentException("Valor de data inválida : A data de término não pode preceder a data de ínicio da tarefa");
            }
            else
            {
                this.DeadLineDate = deadLineDate;
            }

            if(DeadLineDate < DateOnly.FromDateTime(DateTime.Now))
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
            var validateDeadLineDate = DateOnly.TryParseExact(ValidateAndSet(newDeadLineDate, nameof(DeadLineDate)), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDeadLineDate);
            if (validateDeadLineDate == true)
            {
                DeadLineDate = isValidDeadLineDate;
            }
            else
            {
                throw new ArgumentException($"Formato inserido é inválido para o campo {nameof(DeadLineDate)}");
            }
        }
    }
}
