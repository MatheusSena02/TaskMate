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
            Console.WriteLine($"\n[ID: {Id}]\n{taskVerification} {Title}\n    - Descrição: {Description}\n    - Recorrência: {convertedSelectedOption})");
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
            Console.WriteLine("\n--------------------------------------------------------\r");
            Console.WriteLine($"DETALHES DA TAREFA #{Id}");
            Console.WriteLine("--------------------------------------------------------\r");
            Console.WriteLine($"   Título:\t{Title}");
            Console.WriteLine($"   Status:\t{TaskStatus} {taskVerification}");
            Console.WriteLine($"   Tipo:\tTarefa Recorrente\n");
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

        public static RecurringTask CreateTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Recorrente...\n");
            Console.Write("Digite o título da tarefa: ");
            string taskTitle = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.Write("\nDigite a descrição (opcional): ");
            string taskDescription = Console.ReadLine();
            Console.Write("Digite a data de início (dd/mm/aaaa): ");
            var taskStartingDate = BaseTask.ValidateAndSet(Console.ReadLine());
            Console.WriteLine("                 Selecione uma das recorrências de tarefa abaixo");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("| 1 - Todos os dias | 2 - Apenas dias úteis | 3 - Apenas finais de semana |");
            Console.WriteLine("|          4 - Segunda, Quarta e Sexta | 5 - Terça e Quinta |              ");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.Write("                                 Digite a opção : ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nTarefa Recorrente \"{taskTitle}\" criada com sucesso!");
            return new RecurringTask(taskTitle, taskStartingDate, selectedOption, taskDescription);
        }
    }
}
