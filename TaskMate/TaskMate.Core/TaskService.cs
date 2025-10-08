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
                            Console.Write("\t  ");
                            ListSimpleTask(simpleTask);
                        }
                    }
                }else if(task is DeadLineTask deadLineTask)
                {
                    //Executa ListDeadLineTask
                }else if(task is RecurringTask recurringTask)
                {
                    //List RecurringTask
                }
            }
        }

        public void ListSimpleTask(SimpleTask simpleTask)
        {
            if (simpleTask.TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {simpleTask.Id} [⬜] {simpleTask.Title}\n\t- Descrição: {simpleTask.Description}");
            }
            else
            {
                Console.WriteLine($"[ID: {simpleTask.Id} [✅] {simpleTask.Title}\n\t- Descrição: {simpleTask.Description}\n");
            }
        }

        public void ListDeadLineTask(IRepository<BaseTask> irepository)
        {
            var taskList = irepository.GetAllTasks();
            foreach (var task in taskList)
            {
                if (task is SimpleTask simpleTask)
                {
                    if (simpleTask.TaskStatus != statusOption.CONCLUIDA)
                    {
                        Console.WriteLine($"[ID: {simpleTask.Id} [⬜] {simpleTask.Title}\n\t-Descrição: {simpleTask.Description}\n");
                    }
                    else
                    {
                        Console.WriteLine($"[ID: {simpleTask.Id} [✅] {simpleTask.Title}\n\t-Descrição: {simpleTask.Description}\n");
                    }
                }
            }
        }
    }
}
