using BankingPortal.Context;
using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BankingPortal.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly BankPortalDbContext _context;

        public CustomerRepository(BankPortalDbContext context)
        {
            _context = context;
        }

        // Returns customer by Customer Id

        public IEnumerable<Customer> GetCustomers() {
            return _context.Customer;
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customer.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer GetCustomerByUsername(string username)
        {
            return _context.Customer.FirstOrDefault(c => c.Username.ToLower().Equals(username.Trim().ToLower()));
        }

        public Customer AddCustomer(Customer customer)
        {
            using(BankPortalDbContext context = _context)
            {
                context.Customer.Add(customer);
                context.SaveChanges();
            }

            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (BankPortalDbContext context = _context)
            {
                Customer customerOld = GetCustomer(customer.CustomerId);
                IEnumerable<PropertyInfo> props = customer.GetType().GetProperties();

                if (customerOld == null)
                {
                    return null;
                }

                foreach (PropertyInfo prop in props)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (var attr in attrs)
                    {
                        RequiredAttribute requiredAttribute = attr as RequiredAttribute;
                        if (requiredAttribute != null)
                        {
                            PropertyInfo p = customer.GetType().GetProperty(prop.Name);
                            p.SetValue(customerOld, prop.GetValue(customer));
                        }
                    }
                }
                context.SaveChanges();
            }

            return customer;
        }
    }
}
