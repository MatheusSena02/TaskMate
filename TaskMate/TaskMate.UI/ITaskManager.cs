using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal interface ITaskCreator
    {
        SimpleTask GetInfoOAboutSimpleTask();
        DeadLineTask GetInfoAboutDeadLineTask();
        RecurringTask GetInfoAboutRecurringTask();
    }
}
