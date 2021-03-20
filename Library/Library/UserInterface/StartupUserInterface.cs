using System;

namespace Library.UserInterface
{
    public class StartupUserInterface
    {
        public static int Show()
        {
            Console.WriteLine("Bem-vindo ao syslib, escolha a opção no menu abaixo:");
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastro de Clientes");
            Console.WriteLine("2 - Cadastro de Livros");
            Console.WriteLine("3 - Empréstimos de livros");
            Console.WriteLine("4 - Devolução de livros");
            Console.WriteLine("5 - Relatório de movimentação");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.Write("Opção: ");
            var selectedOption = Console.ReadLine();

            return int.Parse(selectedOption);
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
