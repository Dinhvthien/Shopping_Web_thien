using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon");// Đặt tên bảng 
            builder.HasKey(p => p.Id);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.CreateDate).HasColumnType("Date");
            builder.Property(p => p.Status).HasColumnType("int").IsRequired();
			builder.Property(p => p.recipientPhone).HasColumnType("nvarchar(500)");
			builder.Property(p => p.recipientName).HasColumnType("nvarchar(500)");
			builder.Property(p => p.recipientAddress).HasColumnType("nvarchar(500)");

			builder.HasOne(p => p.User).WithMany(c => c.Bills).HasForeignKey(l => l.UserID).HasConstraintName("FK_Bill_User");

        }
    }
}
