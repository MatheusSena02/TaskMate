using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum RecurringOptions
    {
        TODOS_OS_DIAS = 1,
        APENAS_DIAS_UTEIS = 2,
        APENAS_FINAL_DE_SEMANA = 3, 
        SEGUNDA_QUARTA_SEXTA = 4,
        TERCA_QUINTA = 5,
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
            string status = TaskStatus == statusOption.CONCLUIDA ? "[X]" : "[ ]";
            Console.WriteLine($"[ID: {Id}]\n{status} {Title}\n\t- Descrição: {Description}\n\t- (Recorrência: {SelectedRecurringDays})");
        }

        public override void GetDetails()
        {
            Console.WriteLine($"\n\n-------------------------------------------------\r");
            Console.WriteLine($"            DETALHES DA TAREFA #{Id}");
            Console.WriteLine($"\n-------------------------------------------------\r\n");
            Console.WriteLine($"    Título:\t{Title}");
            Console.WriteLine($"    Status:\t{TaskStatus}");
            Console.WriteLine($"    Tipo:\tTarefa Recorrente");
            Console.WriteLine($"    Recorrência:\t{SelectedRecurringDays}");
            Console.WriteLine($"    Descrição:");
            Console.WriteLine($"      {Description}\n");

            if (Subtask.Count > 0)
            {
                foreach (var subtask in Subtask)
                {
                    PrintTask();
                }
            }
        }
    }
}
