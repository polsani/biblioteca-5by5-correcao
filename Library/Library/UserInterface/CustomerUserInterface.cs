using Library.Entities;
using Library.Services;
using System;
using System.Globalization;

namespace Library.UserInterface
{
    public class CustomerUserInterface
    {
        public static void CreateCustomer()
        {
            Console.WriteLine("");
            Console.Write("Para iniciar o cadastro, digite o CPF do cliente: ");
            var document = Console.ReadLine();

            var customerService = new CustomerService();
            if (customerService.Exists(document))
            {
                CustomerAlreadyExists();
                return;
            }

            var customer = new Customer();
            customer.Document = document;

            Console.WriteLine("");
            Console.Write("Nome: ");
            customer.Name = Console.ReadLine();            
            
            Console.Write("Data nascimento (dd/mm/aaaa): ");
            var culture = CultureInfo.GetCultureInfo("pt-BR");
            customer.BirthDate = DateTime.Parse(Console.ReadLine(), culture);

            Console.Write("Telefone: ");
            customer.Phone = Console.ReadLine();

            Console.Write("Endereço: ");
            customer.Street = Console.ReadLine();

            Console.Write("Bairro: ");
            customer.Neighborhood = Console.ReadLine();

            Console.Write("Cidade: ");
            customer.City = Console.ReadLine();

            Console.Write("Estado: ");
            customer.State = Console.ReadLine();

            Console.Write("Cep: ");
            customer.ZipCode = Console.ReadLine();

            if(customerService.Create(customer))
            {
                Console.WriteLine("");
                Console.WriteLine("Cliente cadastrado com sucesso :)");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Os dados do cliente não são válidos. Confira os dados e tente novamente.");
            Console.ReadLine();
        }

        public static void CustomerAlreadyExists()
        {
            Console.WriteLine("");
            Console.WriteLine("Esse cliente já existe em nossa base de dados.");
        }
    }
}
