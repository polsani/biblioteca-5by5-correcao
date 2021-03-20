using Library.UserInterface;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedOption = 1;
            
            do
            {
                selectedOption = StartupUserInterface.Show();

                switch (selectedOption)
                {
                    case 1: 
                        CustomerUserInterface.CreateCustomer();
                        break;
                }

                StartupUserInterface.Clear();
            }
            while (selectedOption != 0);            
        }
    }
}
