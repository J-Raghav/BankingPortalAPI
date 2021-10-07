using BankingPortal.DataModels;
using BankingPortal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Services
{
    public interface ILoanService
    {
        public EducationLoan ApplyEducationLoan(EducationLoan loanData);

        public PersonalLoan ApplyPersonalLoan(PersonalLoan loanData);

    }
}
