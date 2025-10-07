using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public enum statusOption
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

        private readonly Guid _id = Guid.Empty;
        public Guid Id
        {
            get
            {
                return this._id;
            }
        }

        private statusOption _taskStatus; 
        public statusOption TaskStatus
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

        private List<BaseTask> _substask = new List<BaseTask>();
        public List<BaseTask> Subtask
        {
            get
            {
                return this._substask;
            }
            set
            {
                _substask = value;
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
            this._taskStatus = statusOption.NAO_INICIADA;
            this._id = Guid.NewGuid();
        }

        public void MarkAsComplete()
        {
            this._taskStatus = statusOption.CONCLUIDA;
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
                _startingDate = DateOnly.Parse(newStartingDate);
            }
        }

        public virtual void GetDetails()
        {
            Console.WriteLine($"ID da tarefa: {Id}");
            Console.WriteLine($"Título: {Title}");
            Console.WriteLine($"Descrição: {Description}");
            Console.WriteLine($"Status: {TaskStatus}");
            Console.WriteLine($"Data de criação: {StartingDate}");
        }
    }
}
