using System;
using BankingPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankingPortal.Context
{
    public partial class BankPortalDbContext : DbContext
    {
        public BankPortalDbContext()
        {
        }

        public BankPortalDbContext(DbContextOptions<BankPortalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<EducationLoan> EducationLoan { get; set; }
        public virtual DbSet<PersonalLoan> PersonalLoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*            if (!optionsBuilder.IsConfigured)
                        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BankPortalDb;Integrated Security=True;Pooling=False");
                        }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CitizenStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Citizenship)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GuardianName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GuardianType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityDocName)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityDocNumber)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InitialDepositAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MartialStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RefAccNumber)
                    .HasColumnName("refAccNumber")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RefAddress)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RefName)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EducationLoan>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__Educatio__4F5AD457DB53F059");

                entity.Property(e => e.AnnualIncome).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Course)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CourseFee).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FatherCurrentCompanyExp).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FatherOccupation)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FatherTotalExp).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanApplyDate).HasColumnType("datetime");

                entity.Property(e => e.LoanDuration).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanIssueDate).HasColumnType("datetime");

                entity.Property(e => e.LoanType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateOfInterest).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RationCardNo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.EducationLoan)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Education__Custo__36B12243");
            });

            modelBuilder.Entity<PersonalLoan>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__Personal__4F5AD457A4F81E51");

                entity.Property(e => e.AnnualIncome).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Company)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentCompanyExp)
                    .HasColumnName("currentCompanyExp")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Designation)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanApplyDate).HasColumnType("datetime");

                entity.Property(e => e.LoanDuration).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LoanIssueDate).HasColumnType("datetime");

                entity.Property(e => e.LoanType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateOfInterest).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalExp)
                    .HasColumnName("totalExp")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PersonalLoan)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__PersonalL__Custo__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
