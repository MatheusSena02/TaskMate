using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;
using TaskMate.Infrastructure;

namespace TaskMate.UI
{
    public class UserInterface : ITaskManager <BaseTask>
    {
        private IRepository<BaseTask> _inMemoryRepository;
        public UserInterface(IRepository<BaseTask> inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
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
                    _inMemoryRepository.AddTask(TaskManager.CreateSimpleTask());
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

        public SimpleTask CreateSimpleTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleSimpleTask = Console.ReadLine();
            if (String.IsNullOrEmpty(titleSimpleTask))
            {
                throw new ArgumentException("A tarefa não pode conter 'title' vazio ou nulo");
            }
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            try
            {
                var startingDateSimple = DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDate);
                if (startingDateSimple == true)
                {
                    Console.WriteLine("Tareda criada com Sucesso!");
                    return new SimpleTask(titleSimpleTask, isValidDate, descriptionSimpleTask);
                }
                else
                {
                    throw new ArgumentException("Formato de data inválido. Tente inserir novamente o valor para data de início");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Não foi possível criar a tarefa X");
            return null;
        }
    }
}
