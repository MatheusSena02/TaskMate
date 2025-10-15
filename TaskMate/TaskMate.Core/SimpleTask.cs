using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class SimpleTask : BaseTask
    {
        public SimpleTask(string title, DateOnly startingDate, string description = "") : base(title, startingDate, description)
        {
        }

        public override string PrintTask()
        {
            string status = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            return $"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}";
        }

        public override string GetDetails()
        {
            return $"\n\n-------------------------------------------------\r\n" +
                    $"            DETALHES DA TAREFA #{Id}" +
                    $"\n-------------------------------------------------\r\n" +
                    $"    Título:\t{Title}\n" +
                    $"    Status:\t{TaskStatus}\n" +
                    $"    Descrição:\n" +
                    $"      {Description}\n";
        }

    }
}
