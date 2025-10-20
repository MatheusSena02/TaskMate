using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal class ViewModel
    {
        private readonly string Title = String.Empty;

        private readonly Guid Id;

        private readonly StatusOption TaskStatus;

        private readonly string Description = String.Empty;

        private readonly DateOnly StartingDate;

        private readonly List<BaseTask> Substasks = new();

        public ViewModel(BaseTask task)
        {
            Title = task.Title; 
            Id = task.Id;
            TaskStatus = task.TaskStatus; 
            Description = task.Description; 
            StartingDate = task.StartingDate;
            Substasks.AddRange(task.SubtasksList);
        }

        public virtual void PrintTask()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"\n\t[ID: {Id}\n{taskVerification} {Title}\n - Descrição: {Description}");
        }

        public virtual void GetDetails()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"            DETALHES DA TAREFA #{Id}");
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"   Título:\t{Title}");
            Console.WriteLine($"   Status:\t{TaskStatus} {taskVerification}");
            Console.WriteLine($"   Tipo:\tTarefa Simples\n");
            Console.WriteLine($"   Descrição:\n   {Description}.\n");
            Console.WriteLine($"   Subtarefas:");
            if(Substasks.Count > 0)
            {
                for(int i = 0; i < Substasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Substasks[i]}");
                }
            }
        }
    }
}
