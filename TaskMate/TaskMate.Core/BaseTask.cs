using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum StatusOption
    {
        NAO_INICIADA,
        EM_PROGRESSO,
        CONCLUIDA,
        ATRASADA
    }

    public abstract class BaseTask
    {
        public string Title { get; set; } = String.Empty;

        public Guid Id { get; } = Guid.NewGuid();

        public StatusOption TaskStatus { get; set; } 
     
        public string Description { get; set; } = String.Empty;

        public List<BaseTask> SubtasksList { get; set; } = new();

        public DateOnly StartingDate { get; set; }

        public BaseTask(string title, string startingDate, string description = "")
        {
            this.Title = ValidateAndSet(title);
            this.StartingDate = ValidateDate(ValidateAndSet(startingDate));
            this.Description = description;
        }

        public void MarkAsComplete()
        {
            this.TaskStatus = StatusOption.CONCLUIDA;
        }

        public void UpdateTitle(string newTitle)
        {
           if(!String.IsNullOrEmpty(newTitle))
            {
                this.Title = newTitle;
            }
        }

        public void UpdateDescription(string newDescription)
        {
            if(!String.IsNullOrEmpty(newDescription))
            {
                this.Description = newDescription;
            }
        }

        public void UpdateStartingDate(string newStartingDate)
        {
            if (!String.IsNullOrEmpty(newStartingDate))
            {
                var validateStartingDate = DateOnly.TryParseExact(ValidateAndSet(newStartingDate), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidStartingDate);
                if (validateStartingDate == true)
                {
                    this.StartingDate = isValidStartingDate;
                }
                else
                {
                    throw new ArgumentException($"Formato inserido é inválido para o campo {nameof(StartingDate)}");

                }
            }
        }

        public static string ValidateAndSet(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"O campo {nameof(value)} não pode ser vazio ou nulo");
            }
            return value.Trim();
        }

        public static DateOnly ValidateDate(string date)
        {
            var validationDate = DateOnly.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidDate);
            
            if(validationDate != true)
            {
                throw new ArgumentNullException($"Formato de data inválido: O campo {nameof(date)} não pode ser criado");
            }
            return isValidDate;
        }
        }
    }
}
