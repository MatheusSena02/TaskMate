using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Infrastructure
{
    internal interface ITaskOperations
    {
        void EditTitle(Guid Id);
        void EditDescription(Guid Id);
        void EditStartingDate(Guid Id);
    }
}
