using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.Configurations
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("HoaDonChiTiet");// Đặt tên bảng 
            builder.HasKey(p => p.Id);//Set Khoa Chinh
            //Cấu hình cho thuộc tính 
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(p => p.Price).HasColumnType("int").IsRequired();// int not null
            builder.HasOne(p => p.Bill).WithMany(c => c.Detail).HasForeignKey(l => l.IDHD);
            builder.HasOne(p => p.Product).WithMany(c => c.Details).HasForeignKey(l => l.IDSP);
        }
    }
}
