using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public interface IRepository<T>
    {
        T? GetById(Guid id);
        List<T> GetAll();
        void Add(T item);
        void Remove(Guid id);
    }

    public abstract class BaseTask
    {
        private string _title = String.Empty;
        public string Title { get; private set; } = String.Empty;

        private Guid _id = Guid.Empty;
        public Guid Id { get { return _id; } }

        private bool _status;
        public bool Status { get; set; }

        private string _description = String.Empty;
        public string Description { get; set; } = String.Empty;

        private List<BaseTask> _substask = new List<BaseTask>();
        public List<BaseTask> Subtask { get;} = new List<BaseTask>();

        public BaseTask(string title, string description = "")
        {
            try
            {
                if (String.IsNullOrEmpty(title))
                {
                    throw new ArgumentException("The 'title' field cannot be null or empty");
                }
                _title = title;
                this._description = description;
                _status = false;
                _id = Guid.NewGuid();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
        }

        public void MarkAsComplete()
        {
            _status = true;
        }

        public void UpdateDescription(string newDescription)
        {
            _description = newDescription;
        }
    }

    public class DeadLineTask(): BaseTask
    {
        private DateOnly _deadLineDate = new DateOnly();
        public DateOnly DeadLineDate { get; set; }

        public DeadLineTask(string title, DateOnly deadLineDate, string description = "") : base(title, description)
        {
            _deadLineDate = deadLineDate;
        }

    }
}
