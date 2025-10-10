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

        public override void PrintTask()
        {
            string status = TaskStatus == statusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}");
        }

        public override void GetDetails()
        {
            Console.WriteLine($"\n\n-------------------------------------------------\r");
            Console.WriteLine($"            DETALHES DA TAREFA #{Id}");
            Console.WriteLine($"\n-------------------------------------------------\r\n");
            Console.WriteLine($"    Título:\t{Title}");
            Console.WriteLine($"    Status:\t{TaskStatus}");
            Console.WriteLine($"    Tipo:\tTarefa Simples");
            Console.WriteLine($"    Descrição:");
            Console.WriteLine($"      {Description}\n");

            if(Subtask.Count > 0)
            {
                foreach(var subtask in Subtask)
                {
                    PrintTask();
                }
            }
        }

    }
}
