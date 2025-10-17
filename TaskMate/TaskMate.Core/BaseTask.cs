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

        public BaseTask(string title, DateOnly startingDate, string description = "")
        {
            this.Title = title;
            this.StartingDate = startingDate;
            this.Description = description;
        }

        public void MarkAsComplete()
        {
            this.TaskStatus = StatusOption.CONCLUIDA;
        }

        public void UpdateTitle(string newTitle)
        {
            Title = ValidateAndSet(newTitle, nameof(Title));
        }

        public void UpdateDescription(string newDescription)
        {
            Description = ValidateAndSet(newDescription, nameof(Description));
        }

        public static string ValidateAndSet(string value, string fieldName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"O campo {fieldName} não pode ser vazio ou nulo");
            }
            return value.Trim();
        }

        public void UpdateStartingDate(string newStartingDate)
        {
            var validateStartingDate = DateOnly.TryParseExact(ValidateAndSet(newStartingDate, nameof(StartingDate)), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly isValidStartingDate);
            if(validateStartingDate == true)
            {
                StartingDate = isValidStartingDate;
            }else
            {
                throw new ArgumentException($"Formato inserido é inválido para o campo {nameof(StartingDate)}");
            }
        }
    }
}
