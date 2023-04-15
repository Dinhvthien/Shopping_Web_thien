using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface IBillServices
    {
        public bool CreateBill(Bill p);

        public bool UpdateBill(Bill p);
        public bool DeleteBill(Guid id);
        public Bill GetBillById(Guid id);
       /* public List<Bill> GetBillsByName(string name);*/
        public List<Bill> GetAllBills();
    }
}
