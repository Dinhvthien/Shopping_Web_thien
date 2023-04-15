using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class BillDetailServices : IBillDtailServices
    {
        ShopDbContext context;
        public BillDetailServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateBillDetail(BillDetails p)
        {
            try
            {
                context.BillDetailss.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var billdetail = context.BillDetailss.FirstOrDefault(c => c.Id == id);
                context.BillDetailss.Remove(billdetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillDetails> GetAllBillDetails()
        {
           return context.BillDetailss.ToList();
        }

        public BillDetails GetBillDetailById(Guid id)
        {
            return context.BillDetailss.First(c=>c.Id== id);
        }

        public List<BillDetails> GetBillDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetail(BillDetails p)
        {
            try
            {
                var upBillDetail = new BillDetails();
                upBillDetail.Id= p.Id;
                upBillDetail.IDHD = p.IDHD;
                upBillDetail.IDSP= p.IDSP;
                upBillDetail.Quantity = p.Quantity;
                upBillDetail.Price = p.Price;
                context.BillDetailss.Update(upBillDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
