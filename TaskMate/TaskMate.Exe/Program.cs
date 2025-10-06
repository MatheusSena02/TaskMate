using TaskMate.Core;

Console.Write("Digite o nome: ");
string title = Console.ReadLine();
Console.Write("Digite a data: ");
string dateInsert = Console.ReadLine();
var startingDate = DateOnly.Parse(dateInsert);

var testSimpleTask = new SimpleTask(title, startingDate);
testSimpleTask.GetDetails();

