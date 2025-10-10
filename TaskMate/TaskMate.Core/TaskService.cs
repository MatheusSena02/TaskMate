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
    }
}
