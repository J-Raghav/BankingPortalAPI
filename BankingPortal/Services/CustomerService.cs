using BankingPortal.DataModels;
using BankingPortal.Models;
using BankingPortal.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankingPortal.Services
{
    public class CustomerService : ICustomerService
    {

        protected readonly ICustomerRepository _customerRepo;



        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Customer RegisterCustomer(Customer customer) {

            customer.RegistrationDate = DateTime.Now;
            customer.AccNumber = GenerateAccountNumber().ToString();
            customer.InitialDepositAmount = customer.AccountType.Equals("saving") ? 5000 : 0;

            int age = FindAge(customer.DateOfBirth);
            if(age < 18)
            {
                customer.CitizenStatus = "minor";
            }
            else if( age < 61)
            {
                customer.CitizenStatus = "normal";
            }
            else
            {
                customer.CitizenStatus = "senior";
            }

            ;

            return _customerRepo.AddCustomer(customer);
        }

        public Customer UpdateCustomer(int customerId, Customer customer)
        {

            customer.CustomerId = customerId;
            return _customerRepo.UpdateCustomer(customer);
        }

        public Customer ValidateCredential(LoginModel login)
        {

            string username = login.Username;
            string password = login.Password;

            Customer customerDetail = null;
            IEnumerable<Customer> customers = _customerRepo.GetCustomers();

            Customer customer = customers.FirstOrDefault(customer =>
                customer.Username.ToLower() == username.Trim().ToLower()
                && customer.Password == password.Trim());

            if (customer != null)
            {
                customer.Password = null;
                customerDetail = customer;
            }

            return customerDetail;
        }

        public string GenerateToken(IConfiguration _config, Customer customer)
        {
            // Prepare credentials which will be used to sign the token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims to be present in token
            List<Claim> claims = new List<Claim>() {
                new Claim("CustomerId", customer.CustomerId.ToString()),
            };

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            return handler.WriteToken(token);
        }
        
        public static long GenerateAccountNumber()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0) % (long) Math.Pow(10, 16);
        }

        public static int FindAge(DateTime dob)
        {
            var today = DateTime.Today;

            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;

            return age;
        }
    }

}
