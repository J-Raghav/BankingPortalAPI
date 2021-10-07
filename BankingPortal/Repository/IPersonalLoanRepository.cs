using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public interface IPersonalLoanRepository
    {
        PersonalLoan AddLoanData(PersonalLoan loanData);
    }
}
