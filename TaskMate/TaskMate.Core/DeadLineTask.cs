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
            if (String.IsNullOrEmpty(deadLineDate))
            {
                throw new ArgumentNullException(nameof(deadLineDate), "O campo 'deadLineDate' não pode ser nulo ou vazio");
            }

            var validationDate = DateOnly.TryParseExact(deadLineDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDeadLineDate);
            if(validationDate != true)
            {
                throw new ArgumentException("´Formato de data inválido : Digite novamente para um valor de data que corresponda à formatação adequada");
            }
            if (deadLineDate < startingDate)
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
