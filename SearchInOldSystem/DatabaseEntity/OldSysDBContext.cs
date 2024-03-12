using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SearchInOldSystem.DatabaseEntity
{
    public class OldSysDBContext : DbContext
    {
        public OldSysDBContext()
        {
        }

        public OldSysDBContext(DbContextOptions<OldSysDBContext> options)
            : base(options)
        {
        }

        public  DbSet<Employees> Employees { get; set; }
        public  DbSet<PostSendr> PostSendr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=10.10.102.16;Initial Catalog=OldSysDB;User ID=sa;Password=P@55w0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EnterDate)
                    .HasColumnName("ENTER_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EshryNo)
                    .HasColumnName("ESHRY_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.LtrDes)
                    .HasColumnName("LTR_DES")
                    .HasMaxLength(150);

                entity.Property(e => e.LtrNo)
                    .HasColumnName("LTR_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LtrYear).HasColumnName("ltr_year");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.SltrNo).HasColumnName("SLTR_NO");

                entity.Property(e => e.WplacExpno).HasColumnName("wplac_expno");

                entity.Property(e => e.WplacRecno).HasColumnName("wplac_recno");
            });

            modelBuilder.Entity<PostSendr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("POST_SENDR");

                entity.Property(e => e.EnterDate)
                    .HasColumnName("ENTER_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FilnoAppend).HasColumnName("FILNO_APPEND");

              //  entity.Property(e => e.FilnoEdit).HasColumnName("FILNO_EDIT");

                entity.Property(e => e.FlageSd).HasColumnName("FLAGE_SD");

                entity.Property(e => e.LaterInfor)
                    .HasColumnName("LATER_infor")
                    .HasMaxLength(200);

                entity.Property(e => e.LaterNo).HasColumnName("LATER_no");

                entity.Property(e => e.LtrType)
                    .HasColumnName("LTR_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LtrYear).HasColumnName("ltr_year");

                entity.Property(e => e.OutDate)
                    .HasColumnName("OUT_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlaceoutPlacer)
                    .HasColumnName("PLACEOUT_placer")
                    .HasMaxLength(80);

                entity.Property(e => e.PlaceoutRec)
                    .HasColumnName("PLACEOUT_rec")
                    .HasMaxLength(80);

                entity.Property(e => e.PostTypel)
                    .HasColumnName("POST_typel")
                    .HasMaxLength(50);

                entity.Property(e => e.PostTypeno).HasColumnName("POST_typeno");

                entity.Property(e => e.RecivDate)
                    .HasColumnName("RECIV_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReciveDate)
                    .HasColumnName("RECIVE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordDate)
                    .HasColumnName("RECORD_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordNamel)
                    .HasColumnName("RECORD_namel")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordNameno).HasColumnName("RECORD_nameno");

                entity.Property(e => e.TrnslatDate)
                    .HasColumnName("TRNSLAT_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WplacExpl)
                    .HasColumnName("WPLAC_expl")
                    .HasMaxLength(50);

                entity.Property(e => e.WplacExpno).HasColumnName("WPLAC_expno");

                entity.Property(e => e.WplacRecl)
                    .HasColumnName("WPLAC_recl")
                    .HasMaxLength(50);

                entity.Property(e => e.WplacRecno).HasColumnName("WPLAC_recno");

                entity.Property(e => e.WplacTrnno).HasColumnName("WPLAC_trnno");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
