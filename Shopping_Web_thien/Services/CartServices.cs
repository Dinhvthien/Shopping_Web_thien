using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class CartServices : ICartServices
    {
          
        ShopDbContext context;
        public CartServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                context.Carts.Add(p);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var cart = context.Carts.Find(id);
                context.Carts.Remove(cart);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cart> GetAllCarts()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(p => p.UserID == id);
        }

        public List<Cart> GetCartsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {
                var cart = context.Carts.Find(p.UserID);
                cart.UserID = p.UserID;
                cart.Description = p.Description;
                context.Update(cart);
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
