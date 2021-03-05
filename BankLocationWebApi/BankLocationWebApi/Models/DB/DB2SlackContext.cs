using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class DB2SlackContext : DbContext
    {
        public DB2SlackContext()
        {
        }

        public DB2SlackContext(DbContextOptions<DB2SlackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountsType> AccountsTypes { get; set; }
        public virtual DbSet<BankLocation> BankLocations { get; set; }
        public virtual DbSet<BillingAccount> BillingAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HOVO-PC;Database=DB2Slack;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountsTypeAccountTypeId, "IX_Accounts_Accounts_TypeAccount_Type_Id");

                entity.HasIndex(e => e.CustomersCustomerId, "IX_Accounts_CustomersCustomer_Id");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_Id");

                entity.Property(e => e.AccountsTypeAccountTypeId).HasColumnName("Accounts_TypeAccount_Type_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomersCustomerId).HasColumnName("CustomersCustomer_Id");

                entity.HasOne(d => d.AccountsTypeAccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountsTypeAccountTypeId);

                entity.HasOne(d => d.CustomersCustomer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomersCustomerId);
            });

            modelBuilder.Entity<AccountsType>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.ToTable("Accounts_Types");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_Id");

                entity.Property(e => e.AccountType).HasColumnName("Account_Type");
            });

            modelBuilder.Entity<BankLocation>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("Bank_Locations");

                entity.Property(e => e.BranchId).HasColumnName("Branch_Id");
            });

            modelBuilder.Entity<BillingAccount>(entity =>
            {
                entity.HasKey(e => e.BillingId);

                entity.ToTable("Billing_Accounts");

                entity.HasIndex(e => e.AccountsAccountId, "IX_Billing_Accounts_AccountsAccount_Id");

                entity.HasIndex(e => e.CustomersCustomerId, "IX_Billing_Accounts_CustomersCustomer_Id");

                entity.Property(e => e.BillingId).HasColumnName("Billing_Id");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.AccountsAccountId).HasColumnName("AccountsAccount_Id");

                entity.Property(e => e.BillAmount).HasColumnName("Bill_amount");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomersCustomerId).HasColumnName("CustomersCustomer_Id");

                entity.HasOne(d => d.AccountsAccount)
                    .WithMany(p => p.BillingAccounts)
                    .HasForeignKey(d => d.AccountsAccountId);

                entity.HasOne(d => d.CustomersCustomer)
                    .WithMany(p => p.BillingAccounts)
                    .HasForeignKey(d => d.CustomersCustomerId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.BankLocationsBranchId, "IX_Customers_Bank_LocationsBranch_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.BankLocationsBranchId).HasColumnName("Bank_LocationsBranch_Id");

                entity.Property(e => e.ContactInfo).HasColumnName("Contact_Info");

                entity.Property(e => e.CustomerName).HasColumnName("Customer_Name");

                entity.HasOne(d => d.BankLocationsBranch)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BankLocationsBranchId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
