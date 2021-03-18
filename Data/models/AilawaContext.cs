using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AilawaAPI.Data.models
{
    public partial class AilawaContext : DbContext
    {
        public AilawaContext()
        {
        }

        public AilawaContext(DbContextOptions<AilawaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaseDetails> CaseDetails { get; set; }
        public virtual DbSet<Femaster> Femaster { get; set; }
        public virtual DbSet<LocationMaster> LocationMaster { get; set; }
        public virtual DbSet<StateMaster> StateMaster { get; set; }
        public virtual DbSet<TempCaseDetails> TempCaseDetails { get; set; }
        public virtual DbSet<VendorMaster> VendorMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=NICSI-7;initial catalog=Ailawa;User Id=sa;Password=Ajay@12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CaseDetails>(entity =>
            {
                entity.Property(e => e.CaseDetailsId)
                    .HasColumnName("CaseDetailsID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AlternateNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CaseRefId)
                    .IsRequired()
                    .HasColumnName("CaseRefID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CaseStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientRefNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Doc)
                    .HasColumnName("DOC")
                    .HasColumnType("date");

                entity.Property(e => e.Doi)
                    .HasColumnName("DOI")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FemasterId).HasColumnName("FEMasterID");

                entity.Property(e => e.LandMark)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocationMasterId).HasColumnName("LocationMasterID");

                entity.Property(e => e.LocationType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodOfStayFrom)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodOfStayTo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateMasterId).HasColumnName("StateMasterID");

                entity.Property(e => e.TransactionNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorMasterId).HasColumnName("VendorMasterID");

                entity.HasOne(d => d.Femaster)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.FemasterId)
                    .HasConstraintName("FK_CaseDetails_FEMaster");

                entity.HasOne(d => d.LocationMaster)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.LocationMasterId)
                    .HasConstraintName("FK_CaseDetails_LocationMaster");

                entity.HasOne(d => d.StateMaster)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.StateMasterId)
                    .HasConstraintName("FK_CaseDetails_StateMaster");

                entity.HasOne(d => d.VendorMaster)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.VendorMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseDetails_VendorMaster");
            });

            modelBuilder.Entity<Femaster>(entity =>
            {
                entity.ToTable("FEMaster");

                entity.HasIndex(e => e.Fename)
                    .HasName("UK_FEMaster")
                    .IsUnique();

                entity.Property(e => e.FemasterId)
                    .HasColumnName("FEMasterID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FemailId)
                    .IsRequired()
                    .HasColumnName("FEMailID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fename)
                    .IsRequired()
                    .HasColumnName("FEName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<LocationMaster>(entity =>
            {
                entity.HasIndex(e => e.LocationName)
                    .HasName("UK_LocationMaster")
                    .IsUnique();

                entity.Property(e => e.LocationMasterId)
                    .HasColumnName("LocationMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FemasterId).HasColumnName("FEMasterID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StateMasterId).HasColumnName("StateMasterID");

                entity.HasOne(d => d.Femaster)
                    .WithMany(p => p.LocationMaster)
                    .HasForeignKey(d => d.FemasterId)
                    .HasConstraintName("FK_LocationMaster_FEMaster");

                entity.HasOne(d => d.StateMaster)
                    .WithMany(p => p.LocationMaster)
                    .HasForeignKey(d => d.StateMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationMaster_StateMaster");
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasIndex(e => e.StateName)
                    .HasName("UK_StateMaster")
                    .IsUnique();

                entity.Property(e => e.StateMasterId)
                    .HasColumnName("StateMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempCaseDetails>(entity =>
            {
                entity.ToTable("tempCaseDetails");

                entity.Property(e => e.TempCaseDetailsId)
                    .HasColumnName("TempCaseDetailsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AlternateNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CaseRefId)
                    .IsRequired()
                    .HasColumnName("CaseRefID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientRefNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LandMark)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocationMasterId).HasColumnName("LocationMasterID");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocationType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodOfStayFrom)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodOfStayTo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateMasterId).HasColumnName("StateMasterID");

                entity.Property(e => e.TransactionNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorMasterId).HasColumnName("VendorMasterID");
            });

            modelBuilder.Entity<VendorMaster>(entity =>
            {
                entity.Property(e => e.VendorMasterId)
                    .HasColumnName("VendorMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
