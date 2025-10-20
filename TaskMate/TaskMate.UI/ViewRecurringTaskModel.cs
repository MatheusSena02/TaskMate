using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    internal class ViewRecurringTaskModel : ViewModel
    {
        private RecurringOptions SelectedRecurringDay;

        private Dictionary<RecurringOptions, string> convertedOptions = new()
        {
            {RecurringOptions.SEGUNDA_QUARTA_SEXTA, "Apenas Segunda, Quarta e Sexta" },
            {RecurringOptions.APENAS_DIAS_UTEIS, "Apenas dias úteis" },
            {RecurringOptions.TODOS_OS_DIAS, "Todos os dias" },
            {RecurringOptions.TERCA_QUINTA, "Apenas Terça e Quinta" },
            {RecurringOptions.APENAS_FINAL_DE_SEMANA, "Apenas aos finais de semana" }
        };

        public ViewRecurringTaskModel(RecurringTask task) : base(task)
        {
            this.SelectedRecurringDay = task.SelectedRecurringDays;
        }

        public override void PrintTask()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            string convertedSelectedOption = convertedOptions[SelectedRecurringDay];
            Console.WriteLine($"\n  [ID: {Id}\n{taskVerification} {Title}\n    - Descrição: {Description}\n    - Recorrência: {convertedSelectedOption})");
            if (Substasks.Count > 0)
            {
                Console.WriteLine("- Subtarefas:");
                foreach (var subtask in Substasks)
                {
                    taskVerification = subtask.TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
                    Console.WriteLine($"{taskVerification} {Title}");
                }
            }
        }

        public override void GetDetails()
        {
            string taskVerification = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
            string convertedSelectedOption = convertedOptions[SelectedRecurringDay];
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"            DETALHES DA TAREFA #{Id}");
            Console.WriteLine("-------------------------------------------------\r");
            Console.WriteLine($"   Título:\t{Title}");
            Console.WriteLine($"   Status:\t{TaskStatus} {taskVerification}");
            Console.WriteLine($"   Tipo:\tTarefa Simples\n");
            Console.WriteLine($"   Recorrência:\t{convertedSelectedOption}\n");
            Console.WriteLine($"   Descrição:\n   {Description}.\n");

            if (Substasks.Count > 0)
            {
                Console.WriteLine($"   Subtarefas:");
                for (int i = 0; i < Substasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Substasks[i]}");
                }
            }
        }
    }
}
