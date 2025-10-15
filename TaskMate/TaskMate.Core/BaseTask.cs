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
        private string _title = String.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The 'title' field cannot be null or empty");
                } 
                this._title = value;
            }
        }

        private readonly Guid _id;
        public Guid Id
        {
            get
            {
                return this._id;
            }
        }

        private StatusOption _taskStatus; 
        public StatusOption TaskStatus
        {
            get
            {
                return this._taskStatus;
            }
            set
            {
                this._taskStatus = value;
            }
        }

        private string _description = String.Empty;
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        private List<BaseTask> _substask;
        public List<BaseTask> Subtask
        {
            get
            {
                return this._substask;
            }
        }

        private DateOnly _startingDate; 
        public DateOnly StartingDate
        {
            get
            {
                return _startingDate;
            }
            set
            {
                this._startingDate = value;
            }
        }

        public BaseTask(string title, DateOnly startingDate, string description = "")
        {
            this._title = title;
            this._startingDate = startingDate;
            this._description = description;
            this._taskStatus = StatusOption.NAO_INICIADA;
            this._id = Guid.NewGuid();
        }

        public void MarkAsComplete()
        {
            this._taskStatus = StatusOption.CONCLUIDA;
        }

        public void UpdateTitle(string title)
        {
            if (!String.IsNullOrEmpty(title))
            {
                this._title = title;
            }
        }

        public void UpdateDescription(string newDescription)
        {
            if (!String.IsNullOrEmpty(newDescription))
            {
                this._description = newDescription;
            }
        }

        public void UpdateStartingDate(string newStartingDate)
        {
            if (!String.IsNullOrEmpty(newStartingDate))
            {
                try
                {
                    if(DateOnly.TryParseExact(newStartingDate, "dd/MM/yyyy", out DateOnly resultDate))
                    {
                        _startingDate = resultDate;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid date format. Please enter a valid date.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public virtual string PrintTask()
        {
            return $"[ID: {Id}]\n[ ] {Title}\n\t- Descrição: {Description}";
        }
    }
}
