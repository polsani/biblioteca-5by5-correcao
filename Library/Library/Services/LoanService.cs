using Library.Entities;
using Library.Repositories;
using System;

namespace Library.Services
{
    public class LoanService
    {
        private LoanRepository _loanRepository;

        public LoanService()
        {
            _loanRepository = new LoanRepository();
        }

        public void Create(Loan loan)
        {
            loan.Status = 1; //Emprestado
            loan.LoanDate = DateTime.Now;

            _loanRepository.Create(loan);
        }

        public void Return()
        {

        }

        public bool IsBookAvailableToLoan(long pulledDownNumber)
        {
            return _loanRepository.Read(pulledDownNumber) == null;
        }
    }
}
