using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ACS.Web.DatabaseEntity
{
    public partial class OldSysDBContext : DbContext
    {
        public OldSysDBContext()
        {
        }

        public OldSysDBContext(DbContextOptions<OldSysDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<PostSendr> PostSendr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=10.10.102.6;Initial Catalog=OldSysDB;User ID=sa;Password=sa@2018@");
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

                entity.Property(e => e.LtrDate)
                    .HasColumnName("LTR_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LtrDes)
                    .HasColumnName("LTR_DES")
                    .HasMaxLength(150);

                entity.Property(e => e.LtrNo)
                    .HasColumnName("LTR_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LtrNo1).HasColumnName("ltr_no1");

                entity.Property(e => e.LtrYear).HasColumnName("ltr_year");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.SaveFile)
                    .HasColumnName("SAVE_FILE")
                    .HasMaxLength(50);

                entity.Property(e => e.SltrNo).HasColumnName("SLTR_NO");

                entity.Property(e => e.Uniq)
                    .HasColumnName("uniq")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.WplacExpno).HasColumnName("wplac_expno");

                entity.Property(e => e.WplacRecno).HasColumnName("wplac_recno");
            });

            modelBuilder.Entity<PostSendr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("POST_SENDR");

                entity.Property(e => e.AllSignl)
                    .HasColumnName("All_signl")
                    .HasColumnType("text");

                entity.Property(e => e.Cardno)
                    .HasColumnName("CARDNO")
                    .HasMaxLength(50);

                entity.Property(e => e.Codelist).HasColumnName("codelist");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text");

                entity.Property(e => e.CountryRec)
                    .HasColumnName("COUNTRY_rec")
                    .HasMaxLength(50);

                entity.Property(e => e.EnterDate)
                    .HasColumnName("ENTER_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EshryNo)
                    .HasColumnName("ESHRY_no")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Ettime)
                    .HasColumnName("ETTIME")
                    .HasMaxLength(50);

                entity.Property(e => e.FgCode).HasColumnName("Fg_Code");

                entity.Property(e => e.FileSave)
                    .HasColumnName("FILE_save")
                    .HasMaxLength(50);

                entity.Property(e => e.FilnoAppend).HasColumnName("FILNO_APPEND");

                entity.Property(e => e.FilnoEdit).HasColumnName("FILNO_EDIT");

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

                entity.Property(e => e.NameReclat)
                    .HasColumnName("NAME_reclat")
                    .HasMaxLength(50);

                entity.Property(e => e.Note)
                    .HasColumnName("NOTE")
                    .HasMaxLength(200);

                entity.Property(e => e.OutDate)
                    .HasColumnName("OUT_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OutrDate)
                    .HasColumnName("outr_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlaceoutExp)
                    .HasColumnName("PLACEOUT_exp")
                    .HasMaxLength(80);

                entity.Property(e => e.PlaceoutPlacee)
                    .HasColumnName("PLACEOUT_placee")
                    .HasMaxLength(80);

                entity.Property(e => e.PlaceoutPlacer)
                    .HasColumnName("PLACEOUT_placer")
                    .HasMaxLength(80);

                entity.Property(e => e.PlaceoutRec)
                    .HasColumnName("PLACEOUT_rec")
                    .HasMaxLength(80);

                entity.Property(e => e.PolicyNo)
                    .HasColumnName("POLICY_no")
                    .HasMaxLength(50);

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

                entity.Property(e => e.ReportNo)
                    .HasColumnName("REPORT_no")
                    .HasMaxLength(50);

                entity.Property(e => e.SendDate)
                    .HasColumnName("send_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TriblysDate)
                    .HasColumnName("TRIBLYS_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnslatDate)
                    .HasColumnName("TRNSLAT_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnslatNo).HasColumnName("TRNSLAT_no");

                entity.Property(e => e.ValueNo)
                    .HasColumnName("VALUE_no")
                    .HasMaxLength(50);

                entity.Property(e => e.Weght)
                    .HasColumnName("WEGHT")
                    .HasMaxLength(50);

                entity.Property(e => e.WithLater)
                    .HasColumnName("WITH_later")
                    .HasColumnType("text");

                entity.Property(e => e.WplacExpl)
                    .HasColumnName("WPLAC_expl")
                    .HasMaxLength(50);

                entity.Property(e => e.WplacExpno).HasColumnName("WPLAC_expno");

                entity.Property(e => e.WplacRecl)
                    .HasColumnName("WPLAC_recl")
                    .HasMaxLength(50);

                entity.Property(e => e.WplacRecno).HasColumnName("WPLAC_recno");

                entity.Property(e => e.WplacTrnl)
                    .HasColumnName("WPLAC_trnl")
                    .HasMaxLength(50);

                entity.Property(e => e.WplacTrnno).HasColumnName("WPLAC_trnno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
