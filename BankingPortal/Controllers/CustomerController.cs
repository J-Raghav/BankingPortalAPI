using BankingPortal.DataModels;
using BankingPortal.Models;
using BankingPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankingPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomerService _customerService;

        public CustomerController(IConfiguration config, ICustomerService customerService)
        {
            _config = config;
            _customerService = customerService;
        }


        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] Customer customer)
        {

            try
            {
                Customer c = _customerService.RegisterCustomer(customer);
                return Ok(c);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal Server Error" });
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Customer customer)
        {
            try
            {
                List<Claim> claims = User.Claims.ToList();
                int customerId = Convert.ToInt32(claims.First(claim => claim.Type == "CustomerId").Value);

                Customer c = _customerService.UpdateCustomer(customerId, customer);
                if (c != null)
                    return Ok(c);

                return BadRequest(new { message = "Invalid Customer Details" });
            }catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal Server Error" });
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {

            try
            {
                // Verifying and storing user credentials
                Customer customerDetail = _customerService.ValidateCredential(loginModel);

                // false if user details are invalid or not present in data layer
                if (customerDetail != null)
                {
                    // Generates token with user's details
                    string Token = _customerService.GenerateToken(_config, customerDetail);

                    var loginResponse = new
                    {
                        Data = customerDetail,
                        Token = Token
                    };

                    //Returns details of user with jwt token
                    return Ok(loginResponse);
                }

                // Returns these if user details are null
                return Unauthorized(new { message="Invalid Credentials" });
            }
            catch
            {
                // Catches and logs the exception happend during execution of controller logic
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server Error"});
            }
        }

    }

}
