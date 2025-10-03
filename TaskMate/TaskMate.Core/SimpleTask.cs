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
    }
}
