using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankingPortal.Models
{
    public partial class Customer
    {
        public Customer()
        {
            EducationLoan = new HashSet<EducationLoan>();
            PersonalLoan = new HashSet<PersonalLoan>();
        }

        [Required]
        [RegularExpression(@"[\s\w]+", ErrorMessage = "Name should only contain Characters and spaces")]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string GuardianType { get; set; }

        [Required]
        public string GuardianName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Citizenship { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[MFO]", ErrorMessage = "Gender can only be M/F/O")]
        public string Gender { get; set; }

        [Required]
        public string MartialStatus { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid Phone Number")]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string IdentityDocName { get; set; }

        [Required]
        public string IdentityDocNumber { get; set; }

        [Required]
        public string RefName { get; set; }

        [Required]
        public string RefAccNumber { get; set; }

        [Required]
        public string RefAddress { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string AccNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CitizenStatus { get; set; }
        public decimal? InitialDepositAmount { get; set; }

        public virtual ICollection<EducationLoan> EducationLoan { get; set; }
        public virtual ICollection<PersonalLoan> PersonalLoan { get; set; }
    }
}
