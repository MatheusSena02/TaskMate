using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;
using TaskMate.Infrastructure;

namespace TaskMate.UI
{
    public class UserInterface
    {
        internal string[] selectOptionsTypeOfTask = { "Tarefa Simples", "Tarefa com Prazo", "Tarefa Recorrente" };

        public void ListDetailsOfTask(InMemoryRepository<BaseTask> taskList)
        {
            Console.Write("Digite o ID da tarefa para ver os detalhes: ");
            var requestId = Guid.Parse(Console.ReadLine()); 
            var requestTask = taskList.GetTaskById(requestId);
            requestTask.GetDetails();
        }

        public void CreateTask()
        {
            Console.WriteLine("Qual tipo de tarefa você deseja criar?\r");
            Console.WriteLine($"  [1] Tarefa Simples");
            Console.WriteLine($"  [2] Tarefa com Prazo");
            Console.WriteLine($"  [3] Tarefa Recorrente\n");
            Console.Write("Digite sua opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());   

        }
    }
}
