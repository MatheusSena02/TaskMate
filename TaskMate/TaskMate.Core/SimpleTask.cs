using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class SimpleTask : BaseTask
    {
        public SimpleTask(string title, DateOnly startingDate, string description = "") : base(title, startingDate, description)
        {
        }

        public override void PrintTask()
        {
            if (TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}");
            }
            else
            {
                Console.WriteLine($"[ID: {Id}]\n[X] {Title}\n\t- Descrição: {Description}");
            }
        }
    }
}
