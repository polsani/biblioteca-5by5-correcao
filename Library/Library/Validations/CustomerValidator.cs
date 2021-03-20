using Library.Entities;
using Maoli;

namespace Library.Validations
{
    public class CustomerValidator
    {
        private Customer _customer;

        public CustomerValidator(Customer customer)
        {
            _customer = customer;
        }

        public bool IsValid()
        {
            if (Cpf.Validate(_customer.Document) &&
                _customer.Name != string.Empty)
                return true;
                
            return false;
        }
    }
}
