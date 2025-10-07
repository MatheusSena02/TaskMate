using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum deadLineOptions
    {
        NAO_INICIADA,
        CONCLUIDA,
        ATRASADA,
        EM_PROGRESSO,
    }

    public class DeadLineTask : BaseTask
    {
        private DateOnly _deadLineDate;
        public DateOnly DeadLineDate => _deadLineDate;

        private Dictionary<int, deadLineOptions> _deadLineOption = new()
        {
            { 0, deadLineOptions.NAO_INICIADA},
            { 1, deadLineOptions.CONCLUIDA },
            { 2, deadLineOptions.ATRASADA },
            { 3, deadLineOptions.EM_PROGRESSO }
        };

        public Dictionary<int, deadLineOptions> DeadLineOption {  get { return _deadLineOption; } }

        private deadLineOptions _deadLineStatus;
        public deadLineOptions DeadLineStatus => _deadLineStatus;

        public DeadLineTask(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "") : base(title, startingDate, description)
        {
            this._deadLineDate = deadLineDate;
            if(deadLineDate < DateOnly.FromDateTime(DateTime.Now)){
                this._deadLineStatus = DeadLineOption[2];
            }else
            {
                this._deadLineStatus = DeadLineOption[0];
            }
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Título: {Title}");
            Console.WriteLine($"ID da tarefa: {Id}");
            Console.WriteLine($"Status: {TaskStatus}");
            Console.WriteLine($"Status do Prazo: {DeadLineStatus}");
            Console.WriteLine($"Data de criação: {StartingDate}");
            Console.WriteLine($"Data de entrega: {DeadLineDate}");
        }
    }
}
