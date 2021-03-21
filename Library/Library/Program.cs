using Library.UserInterface;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var selectedOption = 1;
            
            do
            {
                selectedOption = StartupUserInterface.Show();

                switch (selectedOption)
                {
                    case 1: 
                        CustomerUserInterface.CreateCustomer();
                        break;

                    case 2:
                        BookUserInterface.CreateBook();
                        break;

                    case 3:
                        LoanUserInterface.CreateLoan();
                        break;

                    case 4:
                        LoanUserInterface.Return();
                        break;

                    case 5:
                        LoanUserInterface.Report();
                        break;
                }

                StartupUserInterface.Clear();
            }
            while (selectedOption != 0);            
        }
    }
}