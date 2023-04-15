using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("GioHang");// Đặt tên bảng 
            builder.HasKey(p => p.UserID);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.Description).HasMaxLength(1000).IsFixedLength().IsUnicode();
        }
    }
}
