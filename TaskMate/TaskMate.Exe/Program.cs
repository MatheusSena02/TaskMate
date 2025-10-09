 using TaskMate.Core;
using TaskMate.Infrastructure;

InMemoryRepository<BaseTask> taskList =  new InMemoryRepository<BaseTask>();
taskList.AddTask(new DeadLineTask("Quebrar Macedo", DateOnly.Parse("08/10/2025"), DateOnly.Parse("15/10/2025")));
taskList.AddTask(new SimpleTask("Quebrar Macedo", DateOnly.Parse("08/10/2025"), "Sentar macedo no pau"));
taskList.AddTask(new RecurringTask("Quebrar Macedo", DateOnly.Parse("08/10/2025"), 2, "Sentar macedo no pau"));
TaskService taskService = new TaskService(taskList);
taskService.ListAllTask();

Console.Write("Digite o Id da tarefa: ");
string idSelectedTask = Console.ReadLine();
taskList.AddSubstask(Guid.Parse(idSelectedTask), new RecurringTask("Quebrar o Clínicas", DateOnly.Parse("08/10/2025"), 2, "Sentar o cínicas no pau"));

taskService.ListAllTask();
