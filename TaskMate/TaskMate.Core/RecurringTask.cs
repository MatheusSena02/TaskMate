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

        public override RecurringTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa com Prazo...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string selectedTitle = Console.ReadLine();
            Console.Write("\nDigite a descrição (opcional): ");
            string selectedDescription = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            var selectedStartingDate = DateOnly.Parse(Console.ReadLine());
            Console.Write("\n\tSelecione as opções de recorrência da tarefa : ");
            Console.Write("\n| 1 - Todos os dias | 2 - Apenas dias úteis | 3 - Apenas ao finais de semana |\n");
            Console.Write("\t| 4 - Segunda, Quarta e Sexta | 5 - Terça e Quinta |\n");
            Console.Write("\tDigite a opção: ");
            int selectedRecurringOption = Convert.ToInt32(Console.ReadLine());
            return new RecurringTask(selectedTitle, selectedStartingDate, selectedRecurringOption, selectedDescription);
        }
    }
}
