using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("NguoiDung");// Đặt tên bảng 
            builder.HasKey(p => p.UserID);//Set Khoa Chinh
                                          //Cấu hình cho thuộc tính 
            builder.Property(p => p.UserName).HasColumnType("nvarchar(100)");
            builder.Property(p => p.PassWord).HasColumnType("nvarchar(100)");

            builder.Property(p => p.Status).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.Role).WithMany(c => c.Users).HasForeignKey(l => l.RoleID);

        }
    }
}
