using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core;

namespace TaskMate.UI
{
    public class UserInterface <T> where T : BaseTask
    {
        private IRepository<T> _inMemoryRepository;
        public UserInterface(IRepository<T> inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
        }
       
    }
}
