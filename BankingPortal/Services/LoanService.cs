using BankingPortal.Models;
using BankingPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Services
{
    public class LoanService : ILoanService
    {
        protected readonly IEducationLoanRepository _educationRepo;
        protected readonly IPersonalLoanRepository _personalRepo;


        public LoanService(IEducationLoanRepository educationRepo, IPersonalLoanRepository personalRepo)
        {
            _educationRepo = educationRepo;
            _personalRepo = personalRepo;
        }

        public EducationLoan ApplyEducationLoan(EducationLoan educationLoan)
        {
            return _educationRepo.AddLoanData(educationLoan);
        }

        public PersonalLoan ApplyPersonalLoan(PersonalLoan personalLoan)
        {
            return _personalRepo.AddLoanData(personalLoan);
        }
    }
}
