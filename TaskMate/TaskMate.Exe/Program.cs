using TaskMate.UI;
using TaskMate.Core;
using TaskMate.Infrastructure;

Console.ForegroundColor = ConsoleColor.Yellow;
InMemoryRepository<BaseTask> testList = new InMemoryRepository<BaseTask>();
TaskService taskControl = new TaskService(testList);
taskControl.CreateTask();
Console.ForegroundColor = ConsoleColor.Green;
taskControl.ListAllTask();
taskControl.edit();
taskControl.ListAllTask();
