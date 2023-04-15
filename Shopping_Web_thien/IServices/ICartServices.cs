using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface ICartServices
    {
        public bool CreateCart(Cart p);

        public bool UpdateCart(Cart p);
        public bool DeleteCart(Guid id);
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartsByName(string name);
        public List<Cart> GetAllCarts();
    }
}
