using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AI_AUTH_JR.Model
{
    public partial class aiAuthdbContext : DbContext
    {
        public virtual DbSet<ActionLogin> ActionLogin { get; set; }
        public virtual DbSet<Emotions> Emotions { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }

        public aiAuthdbContext(DbContextOptions<aiAuthdbContext> options) : base(options)
        {}

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=rds-mysql.czepthgipwqe.us-west-2.rds.amazonaws.com;port=3306;user=ruben69695;password=qtU^Q1tN0rgw;database=aiAuthdb");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLogin>(entity =>
            {
                entity.ToTable("actionLogin");

                entity.HasIndex(e => e.EmotionId)
                    .HasName("fk_actionLogin_emotions");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("fk_actionLogin_objects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmotionId)
                    .HasColumnName("emotionId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Emotion)
                    .WithMany(p => p.ActionLogin)
                    .HasForeignKey(d => d.EmotionId)
                    .HasConstraintName("fk_actionLogin_emotions");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.ActionLogin)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("fk_actionLogin_objects");
            });

            modelBuilder.Entity<Emotions>(entity =>
            {
                entity.ToTable("emotions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(120);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60);

                entity.Property(e => e.NumberOfEmotions)
                    .HasColumnName("numberOfEmotions")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Objects>(entity =>
            {
                entity.ToTable("objects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(60);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60);

                entity.Property(e => e.NumberOfObjects)
                    .HasColumnName("numberOfObjects")
                    .HasColumnType("int(11)");
            });
        }
    }
}
