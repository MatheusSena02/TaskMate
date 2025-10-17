using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public sealed record DatesOfTask(Guid id, string title, DateOnly startingDate, DateOnly deadLineDate, int recurringDays, string description);
}
