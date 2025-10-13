using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class TaskService 
    {
        private IRepository<BaseTask> _irepository;

        public TaskService(IRepository<BaseTask> irepository)
        {
            _irepository = irepository != null ? irepository : throw new ArgumentNullException(nameof(irepository));
        }

        public void ListAllTask()
        {
            var taskList = _irepository.GetAllTasks();
            foreach (var task in taskList)
            {
                task.PrintTask();
                if(task.Subtask.Count > 0)
                {
                    foreach (var subtask in task.Subtask)
                    {
                        subtask.PrintTask();
                    }
                }
            }
        }

        public void CreateTask()
        {
            Console.WriteLine("Qual tipo de tarefa você deseja criar?\r");
            Console.WriteLine("  [1] Tarefa Simples");
            Console.WriteLine("  [2] Tarefa com Prazo");
            Console.WriteLine("  [3] Tarefa Recorrente\n");
            Console.Write("Digite a sua opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            switch(selectedOption)
            {
                case 1:
                    Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\r\n");
                    Console.Write("Digite o título da tarefa: ");
                    string titleSimpleTask = Console.ReadLine();
                    Console.Write("\nDigite a descrição (opcional): ");
                    string descriptionSimpleTask = Console.ReadLine();
                    Console.Write("\nDigite a data de início da tarefa: ");
                    var startingDateSimpleTask = DateOnly.Parse(Console.ReadLine());
                    _irepository.AddTask(new SimpleTask(titleSimpleTask, startingDateSimpleTask, descriptionSimpleTask));
                    break;
                case 2:
                    Console.WriteLine("\n>> Criando uma nova Tarefa com Prazo...\r\n");
                    Console.Write("Digite o título da tarefa: ");
                    string titleDeadLineTask = Console.ReadLine();
                    Console.Write("\nDigite a descrição (opcional): ");
                    string descriptionDeadLineTask = Console.ReadLine();
                    Console.Write("\nDigite a data de início da tarefa: ");
                    var startingDateDeadLineTask = DateOnly.Parse(Console.ReadLine());
                    Console.Write("\nDigite a data de término da tarefa: ");
                    var endDate = DateOnly.Parse(Console.ReadLine());
                    _irepository.AddTask(new DeadLineTask(titleDeadLineTask, startingDateDeadLineTask, endDate, descriptionDeadLineTask));
                    break;
                case 3:
                    Console.WriteLine("\n>> Criando uma nova Tarefa Recorrente...\r\n");
                    Console.Write("Digite o título da tarefa: ");
                    string titleRecurringTask = Console.ReadLine();
                    Console.Write("\nDigite a descrição (opcional): ");
                    string descriptionRecurringTask = Console.ReadLine();
                    Console.Write("\nDigite a data de início da tarefa: ");
                    var startingDateRecurringTask = DateOnly.Parse(Console.ReadLine());
                    Console.Write("\n\tSelecione as opções de recorrência da tarefa : \n");
                    Console.Write("----------------------------------------------------------------------------------");
                    Console.Write("\n  | 1 - Todos os dias | 2 - Apenas dias úteis | 3 - Apenas ao finais de semana |\n");
                    Console.Write("\t     | 4 - Segunda, Quarta e Sexta | 5 - Terça e Quinta |\n");
                    Console.Write("----------------------------------------------------------------------------------");
                    Console.Write("\n\t\t\tDigite a opção: ");
                    int selectedRecurringOption = Convert.ToInt16(Console.ReadLine());
                    _irepository.AddTask(new RecurringTask(titleRecurringTask, startingDateRecurringTask, selectedRecurringOption, descriptionRecurringTask));
                    break;
                default:
                    Console.WriteLine("Não foi possível criar a tarefa...");
                    break;

            }
        }

    }
}
