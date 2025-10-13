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
                    _irepository.AddTask(TaskCreator.CreateSimpleTask());
                    break;
                case 2:
                    _irepository.AddTask(TaskCreator.CreateDeadLineTask()); 
                    break;
                case 3:
                    _irepository.AddTask(TaskCreator.CreateRecurringTask());
                    break;
                default:
                    Console.WriteLine("Não foi possível criar a tarefa...");
                    break;

            }
        }

    }
}
