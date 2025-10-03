using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        void Clean();
    }

    public abstract class Base
    {
        private string _title = String.Empty;
        public string Title { get; private set; } = String.Empty;

        private Guid _id = Guid.Empty;
        public Guid Id { get { return _id; } }

        private bool _status;
        public bool Status { get; set; }

        private string _description = String.Empty;
        public string Description { get; set; } = String.Empty;

        private List<Base> _substask = new List<Base>();
        public List<Base> Subtask { get;} = new List<Base>();

        public Base(string title, string description = "")
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

        public void UpdateTitle(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                _title = _title;
            }
            else
            {
                _title = title;
            }
        }

        public void UpdateDescription(string newDescription)
        {
            if (String.IsNullOrEmpty(newDescription))
            {
                _description = _description;
            }
            else
            {
                _description = newDescription;
            }
                
        }
    }

    public class Simple : Base
    {
        public SimpleTask(string title, string description = "") : base(title, description)
        {
        }
    }

    public class DeadLineTask: Base
    {
        private DateOnly _deadLineDate = new DateOnly();
        public DateOnly DeadLineDate { get; set; }

        public DeadLineTask(string title, DateOnly deadLineDate, string description = "") : base(title, description)
        {
            this._deadLineDate = deadLineDate;
        }

        public void UpdateDeadLineDateForDate(DateOnly newDeadLineDate)
        {
            _deadLineDate = newDeadLineDate;
        }

        public void UpdateDeadLineDateForDay(int numberOfDays)
        {
            _deadLineDate.AddDays(numberOfDays);
        }
    }

    public class RecurringTask : Base
    {
        private DateOnly _dateBeginning = new DateOnly();
        public DateOnly DateBeginning { get; set; }

        private DateOnly _endDate = new DateOnly();
        public DateOnly EndDate { get; set; }

        public RecurringTask(string title, DateOnly dateBeginning, DateOnly endDate, string description = "") : base(title, description)
        {
            _dateBeginning = dateBeginning;
            _endDate = endDate;
        }

        public void UpdateDaysOfRepeat(List<DateOnly> newDaysOfRepeat)
        {
            _daysOfRepeat = newDaysOfRepeat;
        }

        public void UpdateEndDate(DateOnly newEndDate)
        {
            _endDate = newEndDate;
        }
    }

}
