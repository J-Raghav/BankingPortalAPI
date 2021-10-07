using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers();

        public Customer GetCustomer(int customerId);

        public Customer GetCustomerByUsername(string username);

        public Customer AddCustomer(Customer customer);

        public Customer UpdateCustomer(Customer customer);

    }
}
