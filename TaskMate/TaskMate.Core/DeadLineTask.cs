using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum deadLineOptions
    {
        CONCLUIDA,
        ATRASADA,
        EM_PROGRESSO,
    }

    public class DeadLineTask : BaseTask
    {
        private DateOnly _deadLineDate;
        public DateOnly DeadLineDate => _deadLineDate;

        private Dictionary<int, deadLineOptions> _deadLineStatus = new()
        {
            { 1, deadLineOptions.CONCLUIDA },
            { 2, deadLineOptions.ATRASADA },
            { 3, deadLineOptions.EM_PROGRESSO }
        };

        public Dictionary<int, deadLineOptions> DeadLineStatus {  get { return _deadLineStatus; } }

        public DeadLineTask(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "") : base(title, startingDate, description)
        {
            this._deadLineDate = deadLineDate; 
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Título: {Title}");
            Console.WriteLine($"ID da tarefa: {Id}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Data de criação: {StartingDate}");
            Console.WriteLine($"Data de entrega: {DeadLineDate}");
        }
    }
}
