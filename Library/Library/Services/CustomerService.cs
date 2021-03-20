using Library.Entities;
using Library.Repositories;
using Library.Validations;
using System.Linq;

namespace Library.Services
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            
        }

        public bool Create(Customer customer)
        {
            bool success = false;
            var customerValidator = new CustomerValidator(customer);
            customer.Id = GenerateNextId();

            if(customerValidator.IsValid())
            {
                _customerRepository.Create(customer);
                success = true;
            }

            return success;
        }

        public bool Exists(string document)
        {
            var customer = _customerRepository.Read(document);

            return customer != null;
        }

        private long GenerateNextId()
        {
            var customers = _customerRepository.ReadAll();

            if (customers == null || !customers.Any())
                return 1;

            return customers.Max(x => x.Id) + 1;
        }
    }
}
