using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public static class TaskCreator
    {
        public static SimpleTask CreateSimpleTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            var startingDateSimpleTask = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine($"\nTarefa Simples \"{titleSimpleTask}\" criada com sucesso!\r\n");
            return new SimpleTask(titleSimpleTask, startingDateSimpleTask, descriptionSimpleTask);
        }

        public static DeadLineTask CreateDeadLineTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa com Prazo...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleDeadLineTask = Console.ReadLine();
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionDeadLineTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            var startingDateDeadLineTask = DateOnly.Parse(Console.ReadLine());
            Console.Write("\nDigite a data de término da tarefa: ");
            var endDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine($"\nTarefa com Prazo \"{titleDeadLineTask}\" criada com sucesso!\r\n");
            return new DeadLineTask(titleDeadLineTask, startingDateDeadLineTask, endDate, descriptionDeadLineTask);
        }

        public static RecurringTask CreateRecurringTask()
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
            Console.WriteLine($"\nTarefa Recorrente \"{titleRecurringTask}\" criada com sucesso!\r\n");
            return new RecurringTask(titleRecurringTask, startingDateRecurringTask, selectedRecurringOption, descriptionRecurringTask);
        }
    }
}
