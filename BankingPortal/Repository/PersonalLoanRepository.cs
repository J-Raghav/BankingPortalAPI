using BankingPortal.Context;
using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public class PersonalLoanRepository : IPersonalLoanRepository
    {
        protected readonly BankPortalDbContext _context;

        public PersonalLoanRepository(BankPortalDbContext context)
        {
            _context = context;
        }
        public PersonalLoan AddLoanData(PersonalLoan loanData)
        {
            using (BankPortalDbContext context = _context)
            {
                context.PersonalLoan.Add(loanData);
                context.SaveChanges();
                return loanData;
            }
        }
    }
}
