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
            string status = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
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

        public override BaseTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            var startingDateSimpleTask = DateOnly.Parse(Console.ReadLine());
            return new SimpleTask(titleSimpleTask, startingDateSimpleTask, descriptionSimpleTask);
        }
    }
}
