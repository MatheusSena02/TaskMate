using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    public class UserInterface <T> where T : BaseTask
    {
        private IRepository<T> _inMemoryRepository;
        public UserInterface(IRepository<T> inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
        }

        public void ListAllTask()
        {
            Console.WriteLine(">> Opção selecionada: [2] Listar Todas as Tarefas\r\n");
            Console.WriteLine("========================================\r");
            Console.WriteLine("          SUA LISTA DE TAREFAS\r");
            Console.WriteLine("========================================\r");
            var allTaskList = _inMemoryRepository.GetAllTasks();
            foreach (var task in allTaskList)
            {
                Console.WriteLine(task.PrintTask());
                if (task.Subtask.Count > 0)
                {
                    foreach (var subtask in task.Subtask)
                    {
                        Console.WriteLine(subtask.PrintTask());
                    }
                }
            }
        }

    }
}
