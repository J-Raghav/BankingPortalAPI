using BankingPortal.Context;
using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public class EducationLoanRepository : IEducationLoanRepository
    {
        protected readonly BankPortalDbContext _context;

        public EducationLoanRepository(BankPortalDbContext context)
        {
            _context = context;
        }
        public EducationLoan AddLoanData(EducationLoan loanData)
        {
            using (BankPortalDbContext context = _context)
            {
                context.EducationLoan.Add(loanData);
                context.SaveChanges();
                return loanData;
            }
        }
    }
}
