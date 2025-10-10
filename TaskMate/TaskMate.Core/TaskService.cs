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
    }
}
