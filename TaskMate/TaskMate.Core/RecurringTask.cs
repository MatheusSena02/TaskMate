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
        public RecurringOptions SelectedRecurringDays { get; set; }

        public RecurringTask(string title, DateOnly startingDate, int recurringDays, string description = "") : base(title, startingDate, description)
        {
            this.SelectedRecurringDays = (RecurringOptions)ValidateOptionAndSet(recurringDays);
        }
        public void UpdateSelectedRecurringDays(int newSelectedRecurringDay) 
        {
            if(newSelectedRecurringDay < 0 || newSelectedRecurringDay > 5)
            {
                throw new ArgumentException("Valor inválido : O valor inserido está fora do escopo de opções possíveis");
            }else if((RecurringOptions)newSelectedRecurringDay == SelectedRecurringDays)
            {
                Console.WriteLine("\nA opção selecionada já está habilitada na tarefa");
            }else
            {
                SelectedRecurringDays = (RecurringOptions)newSelectedRecurringDay;
            }
        }
    }
}
