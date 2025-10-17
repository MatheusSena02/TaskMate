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
            if(recurringDays > 5 || recurringDays < 0)
            {
                throw new ArgumentException("O valor informado para seleção da recorrência da tarefa está fora do escopo possível");
            }
            else
            {
                this.SelectedRecurringDays = (RecurringOptions)recurringDays;
            }
        }
        public void UpdateSelectedRecurringDays(int newSelectedRecurringDay) 
        {
            if((RecurringOptions)newSelectedRecurringDay != this.SelectedRecurringDays)
            {
                SelectedRecurringDays = (RecurringOptions)ValidateOptionAndSet(newSelectedRecurringDay);
            }
            else
            {
                Console.WriteLine("A opção selecionada já está selecionada nessa tarefa");
            }

            if (newSelectedRecurringDay > 0 && newSelectedRecurringDay < 5 && (RecurringOptions)newSelectedRecurringDay != this.SelectedRecurringDays)
            {
                SelectedRecurringDays = (RecurringOptions)newSelectedRecurringDay;
            }
            else
            {

            }
        }
        public static int ValidateOptionAndSet(int option)
        {
            if (option > 5 || option < 0)
            {
                throw new ArgumentException("O valor informado para seleção da recorrência da tarefa está fora do escopo possível");
            }
            return option;
        }
    }
}
