using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void GetDetails()
        {
            Console.Write("\nDigite o ID da tarefa para ver os detalhes: ");
            try
            {
                var searchId = Guid.TryParse(Console.ReadLine(), out var isValidID);
                if (searchId == true)
                {
                    var selectedTask = _inMemoryRepository.GetTaskById(isValidID);
                    if (selectedTask != null)
                    {
                        Console.WriteLine(selectedTask.GetDetails());
                        if (selectedTask.Subtask.Any() && selectedTask.Subtask != null)
                        {
                            foreach (var subtask in selectedTask.Subtask)
                            {
                                Console.WriteLine(subtask.PrintTask());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Task not found");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid Id format.Please enter a valid Id.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
