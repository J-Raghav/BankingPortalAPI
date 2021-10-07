using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankingPortal.Models
{
    public partial class EducationLoan
    {
        public string LoanType { get; set; }
        
        [Required]
        public decimal LoanAmount { get; set; }

        public DateTime? LoanApplyDate { get; set; }
        public DateTime? LoanIssueDate { get; set; }
        public decimal RateOfInterest { get; set; }
        
        [Required]
        public decimal LoanDuration { get; set; }
        
        [Required]
        public decimal? CourseFee { get; set; }
        
        [Required]
        public string Course { get; set; }

        [Required]
        public string FatherName { get; set; }
        
        [Required]
        public string FatherOccupation { get; set; }
        
        [Required]
        public decimal? FatherTotalExp { get; set; }

        [Required]
        public decimal? FatherCurrentCompanyExp { get; set; }

        [Required]
        public string RationCardNo { get; set; }

        [Required]
        public decimal? AnnualIncome { get; set; }
        
        public int? CustomerId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
