using Library.Entities;
using Library.Services;
using System;
using System.Globalization;

namespace Library.UserInterface
{
    public class LoanUserInterface
    {
        public static void CreateLoan()
        {
            var loanService = new LoanService();
            var customerService = new CustomerService();
            var bookService = new BookService();

            Console.WriteLine("");
            Console.Write("Para iniciar o empréstimo, digite o nro do tombo do livro: ");
            var pulledDownNumber = long.Parse(Console.ReadLine());

            if (!bookService.Exists(pulledDownNumber))
            {
                Console.WriteLine("");
                Console.Write("Livro não cadastrado, verifique o nro do tombo novamente");
                Console.ReadLine();

                return;
            }                

            if (loanService.IsBookAvailableToLoan(pulledDownNumber))
            {
                var loan = new Loan();

                Console.WriteLine("");
                Console.Write("Insira o CPF do cliente: ");
                var document = Console.ReadLine();
                var customer = customerService.ReadByDocument(document);

                loan.BookPulledDownNumber = pulledDownNumber;
                loan.CustomerId = customer.Id;

                Console.Write("Data devolução (dd/mm/aaaa): ");
                loan.ReturnDate = DateTime.Parse(Console.ReadLine(), new CultureInfo("pt-BR"));

                loanService.Create(loan);

                Console.WriteLine("Livro emprestado com sucesso.");
                Console.ReadLine();
                return;
            }

            BookIsNotAvailableToLoan();
        }

        public static void Return()
        {

        }

        public static void Report()
        {

        }

        private static void BookIsNotAvailableToLoan()
        {
            Console.WriteLine("");
            Console.WriteLine("Esse livro já está emprestado.");
            Console.ReadLine();
        }
    }
}
