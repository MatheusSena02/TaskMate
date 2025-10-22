using TaskMate.Core;
using TaskMate.Infrastructure;
using TaskMate.UI;

var bancoDeTarefas = new InMemoryRepository<BaseTask>();

UserInterface userInterface = new UserInterface(bancoDeTarefas);

userInterface.DisplayController();
userInterface.DisplayController();
userInterface.DisplayController();
userInterface.DisplayController();
userInterface.DisplayController();
userInterface.DisplayController();

