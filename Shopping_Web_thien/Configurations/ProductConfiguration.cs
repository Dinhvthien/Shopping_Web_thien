using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("SanPham");// Đặt tên bảng 
            builder.HasKey(p => p.Id);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Status).HasColumnType("int").IsRequired();
            builder.Property(p => p.avaliabaleQuantity).HasColumnType("int").IsRequired();
            builder.Property(p => p.Supplier).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.photo).HasColumnType("nvarchar(1000)");

        }
    }
}
