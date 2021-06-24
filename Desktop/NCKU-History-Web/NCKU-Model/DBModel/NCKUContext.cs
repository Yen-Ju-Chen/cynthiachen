using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NCKU_Model.DBModel
{
    public partial class NCKUContext : DbContext
    {
        public NCKUContext()
        {
        }

        public NCKUContext(DbContextOptions<NCKUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminGroup> AdminGroups { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DataType> DataTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost,3306;user id=root;password=a123456;database=NCKU", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.10-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .HasColumnType("int(10)")
                    .HasComment("管理者Id");

                entity.Property(e => e.AdminGroupId)
                    .HasColumnType("int(10)")
                    .HasComment("群組Id(參考AdminGroup)");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasColumnType("int(10)")
                    .HasComment("建立人員Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasComment("mail");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("刪除(Y: 刪除)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("管理者姓名");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasComment("密碼(aes加密)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("狀態(Y:啟用 N:停用)");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasComment("更新時間");

                entity.Property(e => e.UpdateUser)
                    .HasColumnType("int(10)")
                    .HasComment("更新人員Id");
            });

            modelBuilder.Entity<AdminGroup>(entity =>
            {
                entity.ToTable("AdminGroup");

                entity.Property(e => e.AdminGroupId)
                    .HasColumnType("int(1)")
                    .HasComment("管理者群組Id");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasColumnType("int(10)")
                    .HasComment("建立人員Id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("群組中文");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("狀態(1:啟用 0:停用)");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasComment("更新時間");

                entity.Property(e => e.UpdateUser)
                    .HasColumnType("int(10)")
                    .HasComment("更新人員Id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(10)")
                    .HasComment("類別Id");

                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("類別代碼");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("類別中文");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasColumnType("int(10)")
                    .HasComment("建立人員Id");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("刪除(Y: 刪除)");

                entity.Property(e => e.Sorting)
                    .HasColumnType("int(3)")
                    .HasComment("排序(小>大，前>後)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("狀態(Y:啟用 N:停用)");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasComment("更新時間");

                entity.Property(e => e.UpdateUser)
                    .HasColumnType("int(10)")
                    .HasComment("更新人員Id");
            });

            modelBuilder.Entity<DataType>(entity =>
            {
                entity.ToTable("DataType");

                entity.Property(e => e.DataTypeId)
                    .HasColumnType("int(10)")
                    .HasComment("資料型態Id");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(6)
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasColumnType("int(10)")
                    .HasComment("建立人員Id");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("刪除(Y: 刪除)");

                entity.Property(e => e.Sorting)
                    .HasColumnType("int(3)")
                    .HasComment("排序(小>大，前>後)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true)
                    .HasComment("狀態(Y:啟用 N:停用)");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("資料型態中文");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(6)
                    .HasComment("更新時間");

                entity.Property(e => e.UpdateUser)
                    .HasColumnType("int(10)")
                    .HasComment("更新人員Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
