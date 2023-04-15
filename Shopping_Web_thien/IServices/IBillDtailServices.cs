using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface IBillDtailServices
    {
        public bool CreateBillDetail(BillDetails p);

        public bool UpdateBillDetail(BillDetails p);
        public bool DeleteBillDetail(Guid id);
        public BillDetails GetBillDetailById(Guid id);
        public List<BillDetails> GetBillDetailsByName(string name);
        public List<BillDetails> GetAllBillDetails();
    }
}
