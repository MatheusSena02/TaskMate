using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core
{
    public class TaskService
    {
        private IRepository<Base> irepository;

        public TaskService(IRepository<Base> irepository)
        {
            this.irepository = irepository;
        }


    }
}
