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

        public void ListAllTask(IRepository<BaseTask> irepository)
        {
            var taskList = irepository.GetAllTasks();
            foreach(var task in taskList)
            {
                if(task is SimpleTask simpleTask)
                {
                    if(simpleTask.Subtask.Count == 0)
                    {
                        ListSimpleTask(simpleTask);
                    }
                    else if(simpleTask.Subtask.Count > 0)
                    {
                        ListSimpleTask(simpleTask);
                        Console.WriteLine("\t- Subtarefas:");
                        foreach(var subtask in simpleTask.Subtask)
                        {
                            ListSubtask(subtask);
                        }
                    }
                }else if(task is DeadLineTask deadLineTask)
                {
                    if(deadLineTask.Subtask.Count == 0)
                    {
                        ListDeadLineTask(deadLineTask);
                    }else if(deadLineTask.Subtask.Count > 0)
                    {
                        ListDeadLineTask(deadLineTask);
                        Console.WriteLine("\t- Subtarefas:");
                        foreach(var subtask in deadLineTask.Subtask)
                        {
                            ListSubtask(subtask);
                        }
                    }
                }else if(task is RecurringTask recurringTask)
                {
                    if(recurringTask.Subtask.Count == 0)
                    {
                        ListRecurringTask(recurringTask);
                    }else if(recurringTask.Subtask.Count > 0)
                    {
                        ListRecurringTask(recurringTask);
                        Console.WriteLine("\t- Subtarefas:");
                        foreach (var subtask in recurringTask.Subtask)
                        {
                            ListSubtask(subtask);
                        }
                    }
                }
            }
        }

        public void ListSimpleTask(BaseTask simpleTask)
        {
            if (simpleTask.TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {simpleTask.Id} [⬜] {simpleTask.Title}\n\t- Descrição: {simpleTask.Description}");
            }
            else
            {
                Console.WriteLine($"[ID: {simpleTask.Id} [✅] {simpleTask.Title}\n\t- Descrição: {simpleTask.Description}");
            }
        }

        public void ListDeadLineTask(BaseTask deadLineTask)
        {
            if(deadLineTask.TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {deadLineTask.Id} [⬜] {deadLineTask.Title}\n\t- Descrição: {deadLineTask.Description}\n\t- (Prazo: {deadLineTask.DeadLineDate})");
            }
            else
            {
                Console.WriteLine($"[ID: {deadLineTask.Id} [✅] {deadLineTask.Title}\n\t- Descrição: {deadLineTask.Description}\n\t- (Prazo: {deadLineTask.DeadLineDate})");
            }
        }

        public void ListRecurringTask(BaseTask recurringTask)
        {
            if(recurringTask.TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {recurringTask.Id} [⬜] {recurringTask.Title}\n\t- Descrição: {recurringTask.Description}\n\t- (Recorrência: {recurringTask.SelectedRecurringDays}");
            }
            else
            {
                Console.WriteLine($"[ID: {recurringTask.Id} [✅] {recurringTask.Title}\n\t- Descrição: {recurringTask.Description}\n\t- (Recorrência: {recurringTask.SelectedRecurringDays}");
            }
        }

        public void ListSubtask(BaseTask subtask)
        {
            if(subtask is SimpleTask simpleTaskSubtask)
            {
                Console.Write("\t  - ");
                ListSimpleTask(simpleTaskSubtask);
                Console.WriteLine();

            }else if(subtask is  DeadLineTask deadLineTaskSubtask)
            {
                Console.Write("\t  - ");
                ListDeadLineTask(deadLineTaskSubtask);
                Console.WriteLine();
            }else if(subtask is RecurringTask recurringTaskSubtask)
            {
                Console.Write("\t  - ");
                ListDeadLineTask(recurringTaskSubtask);
                Console.WriteLine();
            }
        }
    }
}
