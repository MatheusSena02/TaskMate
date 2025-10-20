using TaskMate.Core;
using TaskMate.Infrastructure;
using TaskMate.UI;

var bancoDeTarefas = new InMemoryRepository<BaseTask>();

UserInterface userInterface = new UserInterface(bancoDeTarefas);
bancoDeTarefas.AddTask(new SimpleTask("Teste 1", DateOnly.Parse("22/09/2025"), "Quebrar Macedo"));
bancoDeTarefas.AddTask(new DeadLineTask("Quebrar o Clínicas", DateOnly.Parse("20/10/2025"), DateOnly.Parse("05/12/2025")));
userInterface.DisplayController();
userInterface.DisplayController();
userInterface.DisplayController();

