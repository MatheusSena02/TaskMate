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
        public void ListAllTask()
        {
            var allTaskList = _inMemoryRepository.GetAllTasks();
            foreach (var task in allTaskList)
            {
                if(task.GetType() == typeof(SimpleTask))
                {
                    //chama a função que retorna os dados de simple task
                    //chama função para imprimir tarefas simples
                }else if(task.GetType() == typeof(DeadLineTask))
                {
                    //chama a função que retorna os dados de deadline task
                    //chama função para imprimir tarefas com prazo
                }else if(task.GetType() == typeof(RecurringTask))
                {
                    //chama a função que retorna os dados de recurring task
                    //chama função para imprimir tarefas recorrente

                }
            }
        }
    }
}
