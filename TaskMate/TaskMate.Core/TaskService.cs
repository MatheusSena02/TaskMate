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

        public void EditDescription(Guid selectedId)
        {
            var selectedTask = _irepository.GetTaskById(selectedId);
            Console.WriteLine($"\nTítulo da Tarefa: {selectedTask.Title}");
            Console.WriteLine($"\nDescrição Atual: {selectedTask.Description}\n");
            Console.WriteLine("Digite a nova descrição (deixe em branco para não alterar):");
            string newDescription = Console.ReadLine();
            if(!String.IsNullOrEmpty(newDescription))
            {
                selectedTask.Description = newDescription;
                Console.WriteLine($"\nDescrição da tarefa #{selectedTask.Id} atualizada com sucesso!");
            }
        }
        public void EditStartingDate(Guid selectedId)
        {
            var selectedTask = _irepository.GetTaskById(selectedId);
            Console.WriteLine($"\nTítulo da Tarefa: {selectedTask.Title}");
            Console.WriteLine($"\nData Atual: {selectedTask.StartingDate}\n");
            Console.WriteLine("Digite a nova data (deixe em branco para não alterar):");
            var newStartingDate = Console.ReadLine();
            if(!String.IsNullOrEmpty(newStartingDate))
            {
                selectedTask.StartingDate = DateOnly.Parse(newStartingDate);
            }
            Console.WriteLine($"\nData da tarefa #{selectedTask.Id} atualizada com sucesso!");
        }
        public void EditEndDate(Guid selectedId)
        {
            var selectedTask = _irepository.GetTaskById(selectedId);
            if(selectedTask is DeadLineTask selectedDeadLineTask)
            {
                Console.WriteLine($"\nTítulo da Tarefa: {selectedDeadLineTask.Title}");
                Console.WriteLine($"\nData de Término Atual: {selectedDeadLineTask.DeadLineDate}\n");
                Console.WriteLine("Digite a nova data (deixe em branco para não alterar):");
                var newDeadLineDate = Console.ReadLine();
                if (!String.IsNullOrEmpty(newDeadLineDate))
                {
                    selectedDeadLineTask.DeadLineDate = DateOnly.Parse(newDeadLineDate);
                }
                Console.WriteLine($"\nData de Término da tarefa #{selectedTask.Id} atualizada com sucesso!");
            }
            else
            {
                Console.Write("\nO Id da tarefa informado não corresponde ao tipo de Tarefa com Prazo");
            }
        }
        public void EditRecurringOption(Guid selectedId)
        {
            var selectedTask = _irepository.GetTaskById(selectedId);
            if(selectedTask is RecurringTask selectedRecurringTask)
            {
                Console.WriteLine($"\nTítulo da Tarefa: {selectedRecurringTask.Title}");
                Console.WriteLine($"\nRecorrência Atual: {selectedRecurringTask.SelectedRecurringDays}\n");
                Console.Write("----------------------------------------------------------------------------------");
                Console.Write("\n  | 1 - Todos os dias | 2 - Apenas dias úteis | 3 - Apenas ao finais de semana |\n");
                Console.Write("\t     | 4 - Segunda, Quarta e Sexta | 5 - Terça e Quinta |\n");
                Console.Write("----------------------------------------------------------------------------------");
                Console.WriteLine("Digite a nova opção de recorrência (deixe em branco para não alterar):");
                int newRecurringOption = Convert.ToInt32(Console.ReadLine());
                if (newRecurringOption > 0 && newRecurringOption < 5)
                {
                    selectedRecurringTask.SelectedRecurringDays = (RecurringOptions)newRecurringOption;
                }
                Console.WriteLine($"\nData da tarefa #{selectedTask.Id} atualizada com sucesso!");
            }
            else
            {
                Console.Write("\nO Id da tarefa informado não corresponde ao tipo de Tarefa Recorrente");
            }
        }

        public void EditTitle(Guid selectedId)
        {
            var selectedTask = _irepository.GetTaskById(selectedId);
            Console.WriteLine($"\nTítulo Atual: {selectedTask.Title}");
            Console.WriteLine("Digite o novo título (deixe em branco para não alterar):");
            string newTitle = Console.ReadLine();
            if(!String.IsNullOrEmpty(newTitle))
            {
                selectedTask.Description = newTitle;
                Console.WriteLine($"\nDescrição da tarefa #{selectedTask.Id} atualizada com sucesso!");
            }
            
        }
    }
}
