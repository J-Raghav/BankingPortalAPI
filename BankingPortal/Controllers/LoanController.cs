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
    public class LoanController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoanService _loanService;

        public LoanController(IConfiguration config, ILoanService loanService)
        {
            _config = config;
            _loanService = loanService;
        }


        [HttpPost]
        [Route("apply/education")]
        public IActionResult ApplyEducation([FromBody] EducationLoan loanData)
        {
/*            try
            {*/
                List<Claim> claims = User.Claims.ToList();
                int customerId = Convert.ToInt32(claims.First(claim => claim.Type == "CustomerId").Value);
                loanData.CustomerId = customerId;
                loanData.LoanType = "education";

                loanData.RateOfInterest = 15;
                loanData.LoanApplyDate = DateTime.Now;
                loanData.LoanIssueDate = DateTime.Now;

                _loanService.ApplyEducationLoan(loanData);

                return Ok(new { message = "Loan Application submitted successfully", data = loanData});
/*            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server Error" });
            }*/
        }

        [HttpPost]
        [Route("apply/personal")]
        public IActionResult ApplyPersonal([FromBody] PersonalLoan loanData)
        {
/*            try
            {*/
                List<Claim> claims = User.Claims.ToList();
                int customerId = Convert.ToInt32(claims.First(claim => claim.Type == "CustomerId").Value);

                loanData.CustomerId = customerId;
                loanData.LoanType = "personal";

            loanData.RateOfInterest = 15;
                loanData.LoanApplyDate = DateTime.Now;
                loanData.LoanIssueDate = DateTime.Now;

                _loanService.ApplyPersonalLoan(loanData);

                return Ok(new { message = "Loan Application submitted successfully", data = loanData });
/*            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server Error" });
            }*/
        }
    }

}
