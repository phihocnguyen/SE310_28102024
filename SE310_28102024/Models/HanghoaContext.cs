using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SE310_WebAPI.Models
{
    public partial class HanghoaContext : DbContext
    {
        public HanghoaContext()
        {
        }

        public HanghoaContext(DbContextOptions<HanghoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HangHoa> HangHoas { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=Hanghoa;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.ToTable("HangHoa");

                entity.Property(e => e.HangHoaId).HasColumnName("HangHoaID");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("img");

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenHang).HasMaxLength(100);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.ToTable("NguoiDung");

                entity.HasIndex(e => e.TenDangNhap, "UQ__NguoiDun__55F68FC0FD1522BA")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__NguoiDun__A9D105347E677D9E")
                    .IsUnique();

                entity.Property(e => e.NguoiDungId).HasColumnName("NguoiDungID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.MatKhau).HasMaxLength(255);

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
