using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.UI.Interfaces
{
    internal interface IInterfaceUser
    {
        int DisplayMenu();
        void DisplayController();
        void DisplayAllTask();
        void DisplayCreateTask();
        void DisplayRemoveTask();


    }
}
