using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;

namespace TaskMate.UI.ViewModels
{
    internal class ViewDeadLineTaskModel : ViewModel
    {
        private DateOnly DeadLineDate;

        public ViewDeadLineTaskModel(DeadLineTask task) :base(task)
        {
            DeadLineDate = task.DeadLineDate;
        }

        public override void PrintTask()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"\n[ID: {Id}]\n{taskVerification} {Title}\n    - Descrição: {Description}\n    - (Prazo: {DeadLineDate})");
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
            Console.WriteLine("\n--------------------------------------------------------\r");
            Console.WriteLine($"DETALHES DA TAREFA #{Id}");
            Console.WriteLine("--------------------------------------------------------\r");
            Console.WriteLine($"   Título:\t{Title}");
            Console.WriteLine($"   Status:\t{TaskStatus} {taskVerification}");
            Console.WriteLine($"   Tipo:\tTarefa com Prazo\n");
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

        public static DeadLineTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa com Prazo...\n");
            Console.Write("Digite o título da tarefa: ");
            string taskTitle = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.Write("\nDigite a descrição (opcional): ");
            string taskDescription = Console.ReadLine();
            Console.Write("\nDigite a data de início (dd/mm/aaaa): ");
            var taskStartingDate = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.Write("\nDigite a data de término (dd/mm/aaaa): ");
            var taskDeadLineDate = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.WriteLine($"\nTarefa com Prazo \"{taskTitle}\" criada com sucesso!");
            return new DeadLineTask(taskTitle, taskStartingDate, taskDeadLineDate, taskDescription);
        }
    }
}
