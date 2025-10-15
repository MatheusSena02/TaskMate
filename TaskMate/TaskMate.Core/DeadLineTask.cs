using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class DeadLineTask : BaseTask
    {
        private DateOnly _deadLineDate;
        public DateOnly DeadLineDate
        {
            get
            {
                return this._deadLineDate;
            }
            set
            {
                this._deadLineDate = value;
            }
        }

        public DeadLineTask(string title, DateOnly startingDate, DateOnly deadLineDate, string description = "") : base(title, startingDate, description)
        {
            if(deadLineDate < startingDate)
            {
                throw new ArgumentException("Invalid date range: End date precedes start date");
            }
            if(deadLineDate < DateOnly.FromDateTime(DateTime.Now)){
                this.TaskStatus = StatusOption.ATRASADA;
            }
            else
            {
                this.TaskStatus = StatusOption.NAO_INICIADA;
            }
                this._deadLineDate = deadLineDate;
        }

        public void SetStartTask()
        {
            this.TaskStatus = StatusOption.EM_PROGRESSO;
        }

        public void UpdateDeadLineDate(string newDeadLineDate)
        {
            if(!String.IsNullOrEmpty(newDeadLineDate))
            {
                try
                {
                    if(DateOnly.TryParse(newDeadLineDate, "dd/MM/yyyy", out DateOnly resultDeadLineDate))
                    {
                        _deadLineDate = resultDeadLineDate;
                        if (TaskStatus == StatusOption.ATRASADA && _deadLineDate > DateOnly.FromDateTime(DateTime.Now))
                        {
                            TaskStatus = StatusOption.NAO_INICIADA;
                        }
                        else if (TaskStatus == StatusOption.EM_PROGRESSO && _deadLineDate > DateOnly.FromDateTime(DateTime.Now))
                        {
                            TaskStatus = StatusOption.EM_PROGRESSO;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid date format. Please enter a valid date.");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override string PrintTask()
        {
            string status = TaskStatus == StatusOption.CONCLUIDA ? "[X]" : "[ ]";
           return $"[ID: {Id}]\n{status} {Title}\n\t- Descrição: {Description}\n\t- (Prazo: {DeadLineDate})";
        }

        public override string GetDetails()
        {
            return $"\n\n-------------------------------------------------\r\n" +
                   $"            DETALHES DA TAREFA #{Id}" +
                   $"\n-------------------------------------------------\r\n" +
                   $"    Título:\t{Title}\n" +
                   $"    Status:\t{TaskStatus}\n" +
                   $"    Tipo:\tTarefa com Prazo\n" +
                   $"    Prazo final:\t{DeadLineDate}\n\n" +
                   $"    Descrição:\n" +
                   $"      {Description}\n";

        }

        //public override BaseTask CreateTask()
        //{
        //    Console.WriteLine("\n>> Criando uma nova Tarefa com Prazo...\r\n");
        //    Console.Write("Digite o título da tarefa: ");
        //    string titleDeadLineTask = Console.ReadLine();
        //    Console.Write("\nDigite a descrição (opcional): ");
        //    string descriptionDeadLineTask = Console.ReadLine();
        //    Console.Write("\nDigite a data de início da tarefa: ");
        //    var startingDateDeadLineTask = DateOnly.Parse(Console.ReadLine());
        //    Console.Write("\nDigite a data de término da tarefa: ");
        //    var endDate = DateOnly.Parse(Console.ReadLine());
        //    return new DeadLineTask(titleDeadLineTask, startingDateDeadLineTask, endDate, descriptionDeadLineTask);
        //}
    }
}
