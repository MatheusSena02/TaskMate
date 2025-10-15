using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal interface ITaskManager <T>
    {
        SimpleTask CreateSimpleTask();
        DeadLineTask CreateDeadLineTask();
        RecurringTask CreateRecurringTask();

        void EditTitle(T Id);
        void EditDescription(T Id); 
        void EditStartingDate(T Id);

    }
}
