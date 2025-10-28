using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Core
{
    public class SimpleTask : BaseTask
    {
        public SimpleTask(string title, string startingDate, string description = "") : base(title, startingDate, description)
        {
        }
    }
}
