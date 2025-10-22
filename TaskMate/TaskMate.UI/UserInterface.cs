using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    public class UserInterface : IInterfaceUser
    {
        private IRepository<BaseTask> _repository;

        public UserInterface(IRepository<BaseTask> repository)
        {
            _repository = repository;
        }

        public int DisplayMenu()
        {
            Console.WriteLine("\t   Tela Principal");
            Console.WriteLine("========================================");
            Console.WriteLine("      BEM-VINDO(A) AO TASKMATE  ");
            Console.WriteLine("========================================\n");
            Console.WriteLine("O que você gostaria de fazer?\r\n");
            Console.WriteLine("  [1] Listar Todas as Tarefas");
            Console.WriteLine("  [2] Ver Detalhes de uma Tarefa");
            Console.WriteLine("  [3] Criar Nova Tarefa");
            Console.WriteLine("  [4] Editar uma Tarefa");
            Console.WriteLine("  [5] Excluir uma Tarefa");
            Console.WriteLine("  [6] Gerenciar Subtarefas");
            Console.WriteLine("  [7] Ver Histórico de Notificações\n");
            Console.WriteLine("  [0] Sair\n");
            Console.Write("Digite a sua opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            if(selectedOption < 0 || selectedOption > 7)
            {
                throw new ArgumentException("Opção inválida: A opção selecionada se encontra fora do escopo aceitável");
            }
            return selectedOption;
        }

        public void DisplayController()
        {
            int userOption = DisplayMenu();
            switch (userOption)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    DisplayAllTask();
                    break;
                case 2:
                    DisplayGetDetails();
                    break;
                case 3:
                    DisplayCreateTask();
                    break;
                case 4:
                    //Método para editar uma tarefa
                    break;
                case 5:
                    DisplayRemoveTask();
                    break;
                case 6:
                    //Método para gerenciar tarefas
                    break;
                case 7:
                    //Método para ver histórico de notificações
                    break;
                default:
                    throw new ArgumentException("Valor inválido: O valor inserido está fora do escopo possível");
            }
        }

        public void DisplayAllTask()
        {
            Console.WriteLine("\n------------------------------------------------------------------");
            var allTaskList = _repository.GetAllTasks();
            foreach (var task in allTaskList)
            {
                if(task is SimpleTask simpleTask)
                {
                    var viewTask = new ViewSimpleTaskModel(simpleTask);
                    viewTask.PrintTask();
                }else if(task is DeadLineTask deadLineTask)
                {
                    var viewTask = new ViewDeadLineTaskModel(deadLineTask);
                    viewTask.PrintTask();
                }else if(task is RecurringTask recurringTask)
                {
                    var viewTask = new ViewRecurringTaskModel(recurringTask);
                    viewTask.PrintTask();
                }
            }
            Console.WriteLine("\n------------------------------------------------------------------\n");
        }

        public void DisplayGetDetails()
        {
            Console.Write("\nDigite o ID da tarefa para ver os detalhes: ");
            string searchId = Console.ReadLine();
            var searchTask = _repository.GetTaskById(Guid.Parse(searchId));
            if(searchTask != null)
            {
                if (searchTask is SimpleTask simpleTask)
                {
                    var viewTask = new ViewSimpleTaskModel(simpleTask);
                    viewTask.GetDetails();
                }else if(searchTask is DeadLineTask deadLineTask)
                {
                    var viewTask = new ViewDeadLineTaskModel(deadLineTask);
                    viewTask.GetDetails();
                }else if(searchTask is RecurringTask recurringTask)
                {
                    var viewTask = new ViewRecurringTaskModel(recurringTask);
                    viewTask.GetDetails();
                }
            }
            else
            {
                Console.WriteLine("Id inválido : O id digitado não corresponde a uma tarefa existente");
            }
        }

        public void DisplayCreateTask()
        {
            Console.WriteLine("Qual tipo de tarefa você deseja criar?");
            Console.WriteLine("  [1] Tarefa Simples");
            Console.WriteLine("  [2] Tarefa com Prazo");
            Console.WriteLine("  [3] Tarefa Recorrente\n");
            Console.Write("Digite a sua opção : ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());  
            switch(selectedOption)
            {
                case 1:
                    _repository.AddTask(ViewSimpleTaskModel.CreateTask());
                    break;
                case 2:
                    _repository.AddTask(ViewDeadLineTaskModel.CreateTask());
                    break;
                case 3:
                    _repository.AddTask(ViewRecurringTaskModel.CreateTask());
                    break;
                default:
                    throw new ArgumentException("Valor inválido: O valor inserido está fora do escopo possível");
            }
        }

        public void DisplayRemoveTask()
        {
            Console.Write("Digite o ID da tarefa que deseja excluir: ");
            var searchId = Console.ReadLine();
            var searchTask = _repository.GetTaskById(Guid.Parse(searchId));
            if(searchTask != null)
            {
                Console.Write($"Você tem certeza que deseja excluir a tarefa {searchTask.Title}? (S/N): ");
                char selectedOption = Convert.ToChar(Console.ReadLine());  
                if(Char.ToUpper(selectedOption) == 'S')
                {
                    _repository.RemoveTask(Guid.Parse(searchId));
                    Console.WriteLine($"\nTarefa \"{searchTask.Title}\" removida com sucesso!");
                }
            }else
            {
                Console.WriteLine("Id inválido : O id digitado não corresponde a uma tarefa existente");
            }
        }
    }
}
