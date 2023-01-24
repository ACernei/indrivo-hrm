using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using InDrivoHRM.Models.Crm;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace InDrivoHRM.Data
{
  public partial class CrmContext : Microsoft.EntityFrameworkCore.DbContext
  {
        private byte[] key = new byte[] {122, 207, 192, 104, 243, 81, 149, 27, 35, 10, 48, 140, 120, 177, 224, 78};
        private byte[] iv = new byte[] {61, 27, 239, 17, 150, 12, 232, 101, 40, 225, 106, 33, 112, 174, 239, 146};

        private readonly IEncryptionProvider provider;
    public CrmContext(DbContextOptions<CrmContext> options):base(options)
    {
          // var keys = AesProvider.GenerateKey(AesKeySize.AES128Bits);
          this.provider = new AesProvider(this.key, this.iv);
    }

    public CrmContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
          builder.UseEncryption(this.provider);
        base.OnModelCreating(builder);

        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .HasOne(i => i.Contact)
              .WithMany(i => i.Opportunities)
              .HasForeignKey(i => i.ContactId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .HasOne(i => i.OpportunityStatus)
              .WithMany(i => i.Opportunities)
              .HasForeignKey(i => i.StatusId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .HasOne(i => i.Opportunity)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.OpportunityId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .HasOne(i => i.TaskType)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.TypeId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .HasOne(i => i.TaskStatus)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.StatusId)
              .HasPrincipalKey(i => i.Id);


        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .Property(p => p.DueDate)
              .HasColumnType("datetime");

        builder.Entity<InDrivoHRM.Models.Crm.Contact>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .Property(p => p.ContactId)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Opportunity>()
              .Property(p => p.StatusId)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.OpportunityStatus>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .Property(p => p.OpportunityId)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .Property(p => p.TypeId)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.Task>()
              .Property(p => p.StatusId)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.TaskStatus>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<InDrivoHRM.Models.Crm.TaskType>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<InDrivoHRM.Models.Crm.Contact> Contacts
    {
      get;
      set;
    }

    public DbSet<InDrivoHRM.Models.Crm.Opportunity> Opportunities
    {
      get;
      set;
    }

    public DbSet<InDrivoHRM.Models.Crm.OpportunityStatus> OpportunityStatuses
    {
      get;
      set;
    }

    public DbSet<InDrivoHRM.Models.Crm.Task> Tasks
    {
      get;
      set;
    }

    public DbSet<InDrivoHRM.Models.Crm.TaskStatus> TaskStatuses
    {
      get;
      set;
    }

    public DbSet<InDrivoHRM.Models.Crm.TaskType> TaskTypes
    {
      get;
      set;
    }
  }
}
