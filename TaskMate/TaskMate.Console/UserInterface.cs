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
            requestTask.GetDetails();
        }
    }
}
