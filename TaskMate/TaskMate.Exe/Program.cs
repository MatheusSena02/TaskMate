using TaskMate.Core;

Console.Write("Digite o nome: ");
string title = Console.ReadLine();

Console.Write("Digite a data: ");
string dateInsert = Console.ReadLine();
var startingDate = DateOnly.Parse(dateInsert);

Console.Write("Digite a data de entrega: ");
dateInsert = Console.ReadLine();
var deadLineDate = DateOnly.Parse(dateInsert);

Console.WriteLine("\n\n");
var testDeadLineTask = new DeadLineTask(title, startingDate, deadLineDate);
testDeadLineTask.GetDetails();
