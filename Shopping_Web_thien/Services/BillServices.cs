using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using System.Xml.Linq;

namespace Shopping_Website.Services
{
    public class BillServices : IBillServices
    {
        ShopDbContext context;
        public BillServices() 
        {
            context= new ShopDbContext();
        }

        public bool CreateBill(Bill p)
        {
            try
            {
                context.Bills.Add(p);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = context.Bills.Find(id);
                context.Bills.Remove(bill);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(p => p.Id == id);
        }

/*        public List<Bill> GetBillsByName(string name)
        {
            return context.Bills.Where(p => p.N == name).ToList();
        }*/

        public bool UpdateBill(Bill p)
        {
            try
            {
                var bill = context.Bills.Find(p.Id);
                bill.Id = p.Id;
                bill.CreateDate = p.CreateDate;
                bill.UserID= p.UserID;
                bill.Status= p.Status;
                bill.recipientAddress= p.recipientAddress;
                bill.recipientName= p.recipientName;
                bill.recipientPhone=p.recipientPhone;
                context.Update(bill);
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
