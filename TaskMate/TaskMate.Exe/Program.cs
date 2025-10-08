using TaskMate.Core;
using TaskMate.Infrastructure;

TaskService testeInjecao = new TaskService(new InMemoryRepository<BaseTask>());
