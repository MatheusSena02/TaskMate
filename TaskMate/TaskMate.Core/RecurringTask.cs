using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum RecurringOptions
    {
        TODOS_OS_DIAS,
        APENAS_DIAS_UTEIS,
        APENAS_FINAL_DE_SEMANA, 
        SEGUNDA_QUARTA_SEXTA,
        TERCA_QUINTA,
    }
    public class RecurringTask : BaseTask
    {
        private RecurringOptions _selectedRecurringDays;
        public RecurringOptions SelectedRecurringDays => _selectedRecurringDays;

        public RecurringTask(string title, DateOnly startingDate, int recurringDays, string description = "") : base(title, startingDate, description)
        {
            this._selectedRecurringDays = (RecurringOptions)recurringDays;
        }
    }
}
