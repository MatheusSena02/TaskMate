using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal abstract class ViewModel
    {
        protected string Title = String.Empty;

        protected Guid Id;

        protected StatusOption TaskStatus;

        protected string Description = String.Empty;

        protected DateOnly StartingDate;

        protected List<BaseTask> Substasks = new();

        public ViewModel(BaseTask task)
        {
            this.Title = task.Title; 
            this.Id = task.Id;
            this.TaskStatus = task.TaskStatus; 
            this.Description = task.Description; 
            this.StartingDate = task.StartingDate;
            Substasks.AddRange(task.SubtasksList);
        }

        public virtual void PrintTask()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"\n  [ID: {Id}]\n{taskVerification} {Title}\n    - Descrição: {Description}");
            if(Substasks.Count > 0 )
            {
                Console.WriteLine("- Subtarefas:");
                foreach(var subtask in Substasks)
                {
                    taskVerification = subtask.TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
                    Console.WriteLine($"{taskVerification} {Title}");
                }
            }
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
            
            if(Substasks.Count > 0)
            {
                Console.WriteLine($"   Subtarefas:");
                for(int i = 0; i < Substasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Substasks[i]}");
                }
            }
        }
    }
}
