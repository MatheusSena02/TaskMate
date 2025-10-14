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
        public RecurringOptions SelectedRecurringDays
        {
            get
            {
                return _selectedRecurringDays;
            }
            set
            {
                _selectedRecurringDays = value;
            }
        }

        public RecurringTask(string title, DateOnly startingDate, int recurringDays, string description = "") : base(title, startingDate, description)
        {
            this._selectedRecurringDays = (RecurringOptions)recurringDays;
        }

        public override void PrintTask()
        {
            string status = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
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

        public override BaseTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Recorrente...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleRecurringTask = Console.ReadLine();
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionRecurringTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            var startingDateRecurringTask = DateOnly.Parse(Console.ReadLine());
            Console.Write("\n\tSelecione as opções de recorrência da tarefa : \n");
            Console.Write("----------------------------------------------------------------------------------");
            Console.Write("\n  | 1 - Todos os dias | 2 - Apenas dias úteis | 3 - Apenas ao finais de semana |\n");
            Console.Write("\t     | 4 - Segunda, Quarta e Sexta | 5 - Terça e Quinta |\n");
            Console.Write("----------------------------------------------------------------------------------");
            Console.Write("\n\t\t\tDigite a opção: ");
            int selectedRecurringOption = Convert.ToInt16(Console.ReadLine());
            return new RecurringTask(titleRecurringTask, startingDateRecurringTask, selectedRecurringOption, descriptionRecurringTask);
        }
    }
}
