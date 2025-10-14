using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public sealed record CreateSimpleTaskDto(string title, DateOnly startingDate, string description = "");
    public sealed record CreateDeadLineTaskDto(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "");
    public sealed record CreateRecurringTaskDto(string title, DateOnly startingDate, int recurringDays, string description = "");
}
