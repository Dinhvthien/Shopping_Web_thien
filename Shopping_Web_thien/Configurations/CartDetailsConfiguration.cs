using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("GioHangChiTiet");// Đặt tên bảng 
            builder.HasKey(p => p.ID);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.HasOne(p => p.Cart).WithMany(p => p.CarDetail).
                HasForeignKey(p => p.UserID);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetail).
                HasForeignKey(p => p.IDSP);
        }
    }
}
