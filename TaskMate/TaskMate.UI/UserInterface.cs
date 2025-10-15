using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;
using TaskMate.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskMate.UI
{
    public class UserInterface <BaseTask> 
    {
        private InMemoryRepository<T> _inMemoryRepository;
        public UserInterface(IRepository<T> inMemoryRepository)
        {
            _inMemoryRepository = (InMemoryRepository<T>)inMemoryRepository;
        }

        public void CreateTask()
        {
            Console.WriteLine(">> Opção selecionada: [1] Criar Nova Tarefa\r\n");
            Console.WriteLine("Qual tipo de tarefa você deseja criar?\r");
            Console.WriteLine("  [1] Tarefa Simples");
            Console.WriteLine("  [2] Tarefa com Prazo");
            Console.WriteLine("  [3] Tarefa Recorrente");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            switch(selectedOption)
            {
                case 1:
                    Console.Write(">> Criando uma nova Tarefa com Prazo...\r\n");
                    Console.Write("Digite o título da tarefa: ");
                    string simpleTitle = Console.ReadLine();
                    Console.Write("Digite a descrição (opcional): ");
                    string simpleDescription = Console.ReadLine();
                    Console.Write("Digite a data de vencimento (dd/mm/aaaa): ");
                    try
                    {
                        var simpleDate = DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDate);
                        if(simpleDate == true)
                        {
                            _inMemoryRepository.AddTask(TaskManager.CreateSimpleTask());
                        }
                        else
                        {
                            throw new ArgumentException("Invalid date range: End date precedes start date");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Não foi possível criar a tarefa");
                    break;
            }
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
