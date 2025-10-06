using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    enum RecurringOptions
    {
        TODOS_OS_DIAS,
        APENAS_DIAS_UTEIS,
        APENAS_FINAL_DE_SEMANA, 
        SEGUNDA_QUARTA_SEXTA,
        TERCA_QUINTA,
    }
    public class RecurringTask : BaseTask
    {
        private Dictionary<int, RecurringOptions> _options = new()
        {
                { 1, RecurringOptions.TODOS_OS_DIAS },
                { 2, RecurringOptions.APENAS_DIAS_UTEIS },
                { 3, RecurringOptions.APENAS_FINAL_DE_SEMANA },
                { 4, RecurringOptions.SEGUNDA_QUARTA_SEXTA },
                { 5, RecurringOptions.TERCA_QUINTA  }
        };

        public Dictionary<int, RecurringOptions> Options { get { return _options; } }

        public RecurringTask(string title, DateOnly startingDate, string description = "") : base(title, startingDate, description)
        {
        }
    }
}
