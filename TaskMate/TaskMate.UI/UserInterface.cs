using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.UI
{
    public class UserInterface : IInterfaceUser
    {
        public int DisplayMenu()
        {
            Console.WriteLine("\t   Tela Principal");
            Console.WriteLine("========================================");
            Console.WriteLine("      BEM-VINDO(A) AO TASKMATE  ");
            Console.WriteLine("========================================\n");
            Console.WriteLine("O que você gostaria de fazer?\r\n");
            Console.WriteLine("  [1] Listar Todas as Tarefas");
            Console.WriteLine("  [2] Ver Detalhes de uma Tarefa");
            Console.WriteLine("  [3] Criar Nova Tarefa");
            Console.WriteLine("  [4] Editar uma Tarefa");
            Console.WriteLine("  [5] Excluir uma Tarefa");
            Console.WriteLine("  [6] Gerenciar Subtarefas");
            Console.WriteLine("  [7] Ver Histórico de Notificações\n");
            Console.WriteLine("  [0] Sair\n");
            Console.WriteLine("Digite a sua opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            return selectedOption;
        }
    }
}
