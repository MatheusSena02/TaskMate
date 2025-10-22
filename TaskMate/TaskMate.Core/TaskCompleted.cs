using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public delegate void CmopletedTask(BaseTask task);
    public class TaskCompleted
    {
        public static event CmopletedTask? OnCompleted;

        public static void MarkTaskAsCompleted(BaseTask task)
        {
            Console.WriteLine($"Tarefa \"{task.Title}\" marcada como concluída!");
            if( OnCompleted != null )
            {
                OnCompleted(task);
            }
        }
    }
}
