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
        public void ListDetailsOfTask(InMemoryRepository<BaseTask> taskList)
        {
            Console.Write("Digite o ID da tarefa para ver os detalhes: ");
            var requestId = Guid.Parse(Console.ReadLine()); 
            var requestTask = taskList.GetTaskById(requestId);
            if(requestTask == null)
            {
                Console.WriteLine("X Tarefa Não Encontrada. Verifique o ID da tarefa e digite novamente");
            }
            else if(requestTask is DeadLineTask deadLineTask)
            {
                Console.WriteLine($"\n\n-------------------------------------------------\r");
                Console.WriteLine($"            DETALHES DA TAREFA #{deadLineTask.Id}");
                Console.WriteLine($"\n-------------------------------------------------\r\n");
                Console.WriteLine($"    Título:\t{deadLineTask.Title}");
                Console.WriteLine($"    Status:\t{deadLineTask.TaskStatus}");
                Console.WriteLine($"    Tipo:\tTarefa com Prazo");
                Console.WriteLine($"    Prazo final:\t{deadLineTask.DeadLineDate}\n");
                Console.WriteLine($"    Descrição:");
                Console.WriteLine($"      {deadLineTask.Description}\n");
                if()

            }else if(requestTask is RecurringTask recurringTask)
            {

            }
            {
                Console.WriteLine($"\n\n-------------------------------------------------\r");
                Console.WriteLine($"            DETALHES DA TAREFA #{requestTask.Id}");
                Console.WriteLine($"\n-------------------------------------------------\r\n");
                Console.WriteLine($"    Título:\t{requestTask.Title}");
                Console.WriteLine($"    Status:\t{requestTask.TaskStatus}");
                Console.WriteLine($"    Status:\t{requestTask.dead}");

            }
        }

        public 
    }
}
