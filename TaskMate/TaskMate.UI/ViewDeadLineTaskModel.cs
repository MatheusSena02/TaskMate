using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal class ViewDeadLineTaskModel : ViewModel
    {
        private DateOnly DeadLineDate;

        public ViewDeadLineTaskModel(DeadLineTask task) :base(task)
        {
            this.DeadLineDate = task.DeadLineDate;
        }

        public override void PrintTask()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"\n\t[ID: {Id}\n{taskVerification} {Title}\n - Descrição: {Description}\n - (Prazo: {DeadLineDate})");
            if (Substasks.Count > 0)
            {
                Console.WriteLine("- Subtarefas:");
                foreach (var subtask in Substasks)
                {
                    taskVerification = subtask.TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
                    Console.WriteLine($"{taskVerification} {Title}");
                }
            }
        }

        public override void GetDetails()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"            DETALHES DA TAREFA #{Id}");
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"   Título:\t{Title}");
            Console.WriteLine($"   Status:\t{TaskStatus} {taskVerification}");
            Console.WriteLine($"   Tipo:\tTarefa Simples\n");
            Console.WriteLine($"   Prazo:\t{DeadLineDate}\n");
            Console.WriteLine($"   Descrição:\n   {Description}.\n");

            if (Substasks.Count > 0)
            {
                Console.WriteLine($"   Subtarefas:");
                for (int i = 0; i < Substasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Substasks[i]}");
                }
            }
        }
    }
}
