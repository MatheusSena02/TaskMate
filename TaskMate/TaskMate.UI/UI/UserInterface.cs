using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Core;
using TaskMate.Core.Event;
using TaskMate.Core.Interfaces;
using TaskMate.Core.Operation;
using TaskMate.UI.Interfaces;
using TaskMate.UI.ViewModels;

namespace TaskMate.UI
{
    public class UserInterface : IInterfaceUser
    {
        private IRepository<BaseTask> _repository;
        public UserInterface(IRepository<BaseTask> repository)
        {
            _repository = repository;
            TaskCompleted.OnCompleted += (task) =>
            {
                task.MarkAsComplete();
                _repository.UpdateTask(task);
            };
        }

        private void TaskCompleted_OnCompleted()
        {
            throw new NotImplementedException();
        }

        public int DisplayMenu()
        {
            Console.WriteLine("\n============================================");
            Console.WriteLine("|               TELA PRINCIPAL             |");
            Console.WriteLine("============================================");
            Console.WriteLine("|          BEM-VINDO(A) AO TASKMATE        |");
            Console.WriteLine("============================================\n");
            Console.WriteLine("  O que você gostaria de fazer?\r\n");
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
            if (selectedOption < 0 || selectedOption > 7)
            {
                throw new ArgumentException("Opção inválida: A opção selecionada se encontra fora do escopo aceitável");
            }
            return selectedOption;
        }

        public void DisplayController()
        {
            int userOption = DisplayMenu();
            while(userOption > 0)
            {
                userOption = DisplayMenu();
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
                        DisplayUpdateTask();
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
        }

        public void DisplayAllTask()
        {
            Console.WriteLine("\n===========================================\r");
            Console.WriteLine("|          SUA LISTA DE TAREFAS           |");
            Console.WriteLine("===========================================\r");
            var allTaskList = _repository.GetAllTasks();
            if(allTaskList.Count > 0)
            {
                foreach (var task in allTaskList)
                {
                    if (task is SimpleTask simpleTask)
                    {
                        var viewTask = new ViewSimpleTaskModel(simpleTask);
                        viewTask.PrintTask();
                    }
                    else if (task is DeadLineTask deadLineTask)
                    {
                        var viewTask = new ViewDeadLineTaskModel(deadLineTask);
                        viewTask.PrintTask();
                    }
                    else if (task is RecurringTask recurringTask)
                    {
                        var viewTask = new ViewRecurringTaskModel(recurringTask);
                        viewTask.PrintTask();
                    }
                }
            }else
            {
                Console.WriteLine("     Nenhuma tarefa registrada ainda.\r\n Adicione uma tarefa para ver o histórico!");
                Console.WriteLine("===========================================\r\n");
            }
        }

        public void DisplayGetDetails()
        {
            Console.WriteLine("\n>> Opção selecionada: [2] Ver Detalhes de uma Tarefa\r");
            Console.Write("\nDigite o ID da tarefa para ver os detalhes: ");
            string? seletectedId = Console.ReadLine();
            if (!string.IsNullOrEmpty(seletectedId))
            {
                if (Guid.TryParse(seletectedId, out Guid taskId))
                {
                    var searchTask = _repository.GetTaskById(taskId);
                    if (searchTask != null)
                    {
                        if (searchTask is SimpleTask simpleTask)
                        {
                            var viewTask = new ViewSimpleTaskModel(simpleTask);
                            viewTask.GetDetails();
                        }
                        else if (searchTask is DeadLineTask deadLineTask)
                        {
                            var viewTask = new ViewDeadLineTaskModel(deadLineTask);
                            viewTask.GetDetails();
                        }
                        else if (searchTask is RecurringTask recurringTask)
                        {
                            var viewTask = new ViewRecurringTaskModel(recurringTask);
                            viewTask.GetDetails();
                        }
                    }else
                    {
                        Console.WriteLine($"\nErro : Tarefa com ID \"{seletectedId}\" não foi encontrada.");
                        Console.WriteLine("Por favor, verifique o ID e tente novamente.");
                    }
                }
            }
        }

        public void DisplayCreateTask()
        {
            Console.WriteLine("\n>> Opção selecionada: [3] Criar Nova Tarefa\r");
            Console.WriteLine("\nQual tipo de tarefa você deseja criar?");
            Console.WriteLine("  [1] Tarefa Simples");
            Console.WriteLine("  [2] Tarefa com Prazo");
            Console.WriteLine("  [3] Tarefa Recorrente\n");
            Console.Write("Digite a sua opção : ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            switch (selectedOption)
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
            Console.Write("\nDigite o ID da tarefa que deseja excluir: ");
            string? searchId = Console.ReadLine();
            if (!string.IsNullOrEmpty(searchId))
            {
                if (Guid.TryParse(searchId, out Guid isValidId))
                {
                    var searchTask = _repository.GetTaskById(isValidId);
                    if (searchTask != null)
                    {
                        Console.Write($"\nVocê tem certeza que deseja excluir a tarefa \"{searchTask.Title}\"? (S/N): ");
                        string? input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            char selectedOption = Convert.ToChar(input);
                            if (Char.ToUpper(selectedOption) == 'S')
                            {
                                _repository.RemoveTask(isValidId);
                                Console.WriteLine($"\nTarefa \"{searchTask.Title}\" removida com sucesso!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nErro : Tarefa com ID \"{searchId}\" não foi encontrada.");
                        Console.WriteLine("Por favor, verifique o ID e tente novamente.");
                    }
                }
            }
        }

        public void DisplayUpdateTask()
        {
            Console.Write("\nDigite o Id da tarefa que deseja editar : ");
            string? input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                if (Guid.TryParse(input, out Guid isValidId))
                {
                    var searchTask = _repository.GetTaskById(isValidId);
                    if (searchTask != null)
                    {
                        Console.WriteLine("\nO que gostaria de alterar na tarefa? ");
                        Console.WriteLine("  [1] Título");
                        Console.WriteLine("  [2] Descrição");
                        Console.WriteLine("  [3] Data de Início");
                        Console.WriteLine("  [4] Marcar tarefa como \"Concluída\"\n");
                        int selectedOption = Convert.ToInt32(Console.ReadLine());
                        var controllService = new TaskService(_repository);
                        switch (selectedOption)
                        {
                            case 1:
                                Console.WriteLine($"\nTítulo atual da tarefa : {searchTask.Title}");
                                Console.Write("Novo Título da tarefa (deixe em branco para não alterar) : ");
                                string? newTitle = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newTitle))
                                {
                                    controllService.UpdateTitle(isValidId, newTitle);
                                }
                                break;
                            case 2:
                                Console.WriteLine($"\nDescrição atual da tarefa : {searchTask.Description}");
                                Console.Write("Nova Descrição da tarefa (deixe em branco para não alterar) : ");
                                string? newDescription = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newDescription))
                                {
                                    controllService.UpdateDescription(isValidId, newDescription);
                                }
                                break;
                            case 3:
                                Console.WriteLine($"\nData de Início atual da tarefa : {searchTask.StartingDate}");
                                Console.Write("Nova Data de Início da tarefa (deixe em branco para não alterar) : ");
                                string? newStartingdate = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newStartingdate))
                                {
                                    controllService.UpdateStartingDate(isValidId, newStartingdate);
                                }
                                break;
                            case 4:
                                TaskCompleted.MarkTaskAsCompleted(searchTask);
                                break;
                            default:
                                throw new ArgumentException("Valor inválido: O valor inserido está fora do escopo possível");
                        }
                    }
                }
            }
        }

        public void DisplaySubtask()
        {
            Console.WriteLine(">> Opção selecionada: [6] Gerenciar Subtarefas\n");
            Console.Write("Digite o ID da tarefa principal: ");

            if(!Guid.TryParse(Console.ReadLine(), out Guid isValidMainId))
            {
                return;
            }
            var mainTask = _repository.GetTaskById(isValidMainId);

            if(mainTask == null)
            {
                return;
            } 

            Console.WriteLine($"\nGerenciando subtarefas de \"{mainTask.Title}\" :");
            for(int i = 0; i < mainTask.SubtasksList.Count; i++)
            {
                string statusTask = mainTask.SubtasksList[i].TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {statusTask} {mainTask.SubtasksList[i]}");
            }

            Console.WriteLine("\nO que desejar fazer ?");
            Console.WriteLine("  [1] Adicionar nova subtarefa");
            Console.WriteLine("  [2] Marcar subtarefa como concluída/pendente");
            Console.WriteLine("  [3] Remover subtarefa");
            Console.WriteLine("  [0] Voltar ao menu principal\n");

            Console.Write("Digite sua opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());

            switch (selectedOption)
            {
                case 0:
                    DisplayMenu();
                    break;
                case 1:
                    var controllAddSubstask = new TaskService(_repository);
                    controllAddSubstask.AddSubstask
            }
        }


    }
}
