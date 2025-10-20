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
                    //Método para listar todas as tarefas
                    break;
                case 2:
                    //Método para ver detalhes da tarefa
                    break;
                case 3:
                    //Método para criar um nova tarefa
                    break;
                case 4:
                    //Método para editar uma tarefa
                    break;
                case 5:
                    //Método para excluir uma tarefa
                    break;
                case 6:
                    //Método para gerenciar tarefas
                    break;
                case 7:
                    //Método para ver histórico de notificações
                    break;
                default:
                    break;
            }
        }

        public void DisplayAllTask()
        {
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
        }
    }
}
