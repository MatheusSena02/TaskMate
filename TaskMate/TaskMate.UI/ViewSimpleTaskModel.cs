using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal class ViewSimpleTaskModel : ViewModel
    {
        public ViewSimpleTaskModel(SimpleTask task) : base(task) { }

        public override SimpleTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\n");
            Console.Write("Digite o título da tarefa: ");
            string taskTitle = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.Write("\nDigite a descrição (opcional): ");
            string taskDescription = Console.ReadLine();
            Console.Write("Digite a data de início (dd/mm/aaaa): ");
            var taskStartingDate = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.WriteLine($"\nTarefa Simples \"{taskTitle}\" criada com sucesso!");
            return new SimpleTask(taskTitle, taskStartingDate, taskDescription);
        }
    }

}
