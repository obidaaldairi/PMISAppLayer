using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePaymentTarm> InvoicePaymentTarms { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectPhase>()
                .HasOne(pp => pp.Project)
                .WithMany(p => p.ProjectPhases)
                .HasForeignKey(pp => pp.ProjectId);

            builder.Entity<ProjectPhase>()
                .HasOne(pp => pp.Phase)
                .WithMany(p => p.ProjectPhases)
                .HasForeignKey(pp => pp.PhaseId);

            builder.Entity<ProjectPhase>().HasKey(pp => pp.ProjectPhaseId);

            builder.Entity<ProjectPhase>().HasIndex(pp => new { pp.ProjectId, pp.PhaseId }).IsUnique();


            builder.Entity<InvoicePaymentTarm>()
                .HasOne(ipt => ipt.PaymentTerm)
                .WithMany(pt => pt.InvoicePaymentTarms)
                .HasForeignKey(ipt => ipt.PaymentTermId);

            builder.Entity<InvoicePaymentTarm>()
                .HasOne(ipt => ipt.Invoice)
                .WithMany(i => i.InvoicePaymentTarms)
                .HasForeignKey(ipt => ipt.InvoiceId);

            builder.Entity<InvoicePaymentTarm>().HasKey(ipt => new { ipt.PaymentTermId, ipt.InvoiceId });

            builder.Entity<Project>().HasOne(x => x.Client)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.ClientId);
                
        }
    }
}
