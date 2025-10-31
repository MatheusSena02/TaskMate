using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Core
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
        public string Title { get; set; } = string.Empty;

        public Guid Id { get; } = Guid.NewGuid();

        public StatusOption TaskStatus { get; set; } 
     
        public string Description { get; set; } = string.Empty;

        public List<Subtask> SubtasksList { get; set; } = new();

        public DateOnly StartingDate { get; set; }

        public BaseTask(string title, string startingDate, string description = "")
        {
            Title = ValidateAndSet(title);
            StartingDate = ValidateDate(ValidateAndSet(startingDate));
            Description = description;
        }

        public void MarkAsComplete()
        {
            TaskStatus = StatusOption.CONCLUIDA;
        }
        public static string ValidateAndSet(string value)
        {
            if (string.IsNullOrEmpty(value))
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

