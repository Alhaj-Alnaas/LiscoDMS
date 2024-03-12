using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CerpApi.DatabaseEntity
{
    public partial class CERPsHostedContext : DbContext
    {
        public CERPsHostedContext()
        {
        }

        public CERPsHostedContext(DbContextOptions<CERPsHostedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VAllEmployee> VAllEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.10.101.4;Initial Catalog=CERPS_Hosted;User ID=sa;Password=Sq$LiscoCerps$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<VAllEmployee>(entity =>
            {
                //entity.HasNoKey();

                entity.ToView("v_per_m_all_emp");

                entity.Property(e => e.EmpFileNo)
                    .HasMaxLength(6)
                    .HasColumnName("emp_fileno");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(500)
                    .HasColumnName("emp_name");

                entity.Property(e => e.EmpPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("emp_phone");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emp_email");

                entity.Property(e => e.RespCodeId)
                   .HasMaxLength(3)
                   .HasColumnName("resp_code_id");

                entity.Property(e => e.EmpResponsibilitycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("emp_responsibilitycode");

                entity.Property(e => e.PerRespCodeNoName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PerRespCodeNoName");

                entity.Property(e => e.JobCatId)
                   .HasMaxLength(3)
                   .HasColumnName("job_cat_id");

                entity.Property(e => e.JobStatus)
                   .HasMaxLength(3)
                   .HasColumnName("job_status");


                   entity.Property(e => e.DesignationId)
                   .HasMaxLength(3)
                   .HasColumnName("designation_id");

                entity.Property(e => e.JobtypeName)
                   .HasMaxLength(3)
                   .HasColumnName("jobtype_name"); 

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
