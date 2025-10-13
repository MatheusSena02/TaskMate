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

        public void EditTask()
        {
            Console.Write("\nDigite o ID da tarefa que deseja editar: ");
            var selectedId = Guid.Parse(Console.ReadLine());
            var selectedTask = _irepository.GetTaskById(selectedId);
            Console.WriteLine($"\nTítulo da Tarefa: {selectedTask.Title}");
            Console.WriteLine($"\nDescrição Atual: {selectedTask.Description}\n");
            Console.WriteLine("Digite a nova descrição (deixe em branco para não alterar):");
            string newDescription = Console.ReadLine();
            selectedTask.Description = newDescription;
            Console.WriteLine($"\nDescrição da tarefa #{selectedTask.Id} atualizada com sucesso!");
        }

    }
}
