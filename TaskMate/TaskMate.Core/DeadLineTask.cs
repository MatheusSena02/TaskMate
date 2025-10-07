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
            this._deadLineDate = deadLineDate;
            if(deadLineDate < DateOnly.FromDateTime(DateTime.Now)){
                this.TaskStatus = statusOption.ATRASADA;
            }else
            {
                this.TaskStatus = statusOption.NAO_INICIADA;
            }
        }

        public void SetStartTask()
        {
            this.TaskStatus = statusOption.EM_PROGRESSO;
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Título: {Title}");
            Console.WriteLine($"ID da tarefa: {Id}");
            Console.WriteLine($"Status do Prazo: {TaskStatus}");
            Console.WriteLine($"Data de criação: {StartingDate}");
            Console.WriteLine($"Data de entrega: {DeadLineDate}");
        }
    }
}
