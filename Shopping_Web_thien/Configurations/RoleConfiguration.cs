using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("VaiTro");// Đặt tên bảng 
            builder.HasKey(p => p.RoleID);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.RoleName).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");



        }
    }
}
