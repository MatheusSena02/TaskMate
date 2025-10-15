using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    public class TaskManager
    {
        public static SimpleTask CreateSimpleTask()
        {
            Console.WriteLine("\n>> Criando uma nova Tarefa Simples...\r\n");
            Console.Write("Digite o título da tarefa: ");
            string titleSimpleTask = Console.ReadLine();
            if (String.IsNullOrEmpty(titleSimpleTask))
            {
                throw new ArgumentException("A tarefa não pode conter 'title' vazio ou nulo");
            }
            Console.Write("\nDigite a descrição (opcional): ");
            string descriptionSimpleTask = Console.ReadLine();
            Console.Write("\nDigite a data de início da tarefa: ");
            try
            {
                var startingDateSimple = DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDate);
                if(startingDateSimple == true)
                {
                    Console.WriteLine("Tareda criada com Sucesso!");
                    return new SimpleTask(titleSimpleTask, isValidDate, descriptionSimpleTask);
                }
                else
                {
                    throw new ArgumentException("Formato de data inválido. Tente inserir novamente o valor para data de início");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Não foi possível criar a tarefa X");
            return null;
        }
    }
}
