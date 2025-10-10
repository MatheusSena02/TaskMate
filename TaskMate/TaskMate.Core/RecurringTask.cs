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

        public override void PrintTask()
        {
            if (TaskStatus != statusOption.CONCLUIDA)
            {
                Console.WriteLine($"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}\n\t- (Recorrência: {SelectedRecurringDays})");
            }
            else
            {
                Console.WriteLine($"[ID: {Id}]\n[X] {Title}\n\t- Descrição: {Description}\n\t- (Recorrência: {SelectedRecurringDays})");
            }
        }
    }
}
