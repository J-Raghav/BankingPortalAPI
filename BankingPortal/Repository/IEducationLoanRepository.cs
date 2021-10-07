using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public interface IEducationLoanRepository
    {
        EducationLoan AddLoanData(EducationLoan loanData);
    }
}
