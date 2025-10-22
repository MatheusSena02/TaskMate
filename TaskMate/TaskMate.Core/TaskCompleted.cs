using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public delegate void CmopletedTask();
    internal class TaskCompleted
    {
        public event CmopletedTask? OnCompleted;

        public void MarkTaskAsCompleted(BaseTask task)
        {
            Console.WriteLine($"Tarefa \"{task.Title}\" marcada como concluída!");
            if( OnCompleted != null )
            {
                OnCompleted();
            }
        }
    }
}
