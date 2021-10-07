using BankingPortal.DataModels;
using BankingPortal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Services
{
    public interface ICustomerService
    {
        public Customer RegisterCustomer(Customer customer);

        public Customer UpdateCustomer(int customerId, Customer customer);

        public Customer ValidateCredential(LoginModel login);

        public string GenerateToken(IConfiguration _config, Customer customer);

    }
}
