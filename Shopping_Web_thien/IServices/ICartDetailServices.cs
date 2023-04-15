using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface ICartDetailServices
    {
        public bool CreateCardetail(CartDetails p);

        public bool UpdateCartDetails(CartDetails p);
        public bool DeleteCartDetails(Guid id);
		public bool DeleteCartDetailsa(CartDetails cartDetails);
		public CartDetails GetCartDetailsById(Guid id);
        public List<CartDetails> GetCartDetailssByName(string name);
        public List<CartDetails> GetAllCartDetailss();
    }
}
