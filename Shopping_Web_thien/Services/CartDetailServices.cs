using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        ShopDbContext context;

        public CartDetailServices()
        { 
            context = new ShopDbContext();
        }
        public bool CreateCardetail(CartDetails p)
        {
            try
            {
                context.CartDetailss.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
               var delCartService = context.CartDetailss.Find(id);
                context.CartDetailss.Remove(delCartService);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

		public bool DeleteCartDetailsa(CartDetails cartDetails)
		{
			try
			{
				var de = context.CartDetailss.Remove(cartDetails);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}

		}

		public List<CartDetails> GetAllCartDetailss()
        {
            return context.CartDetailss.ToList();
        }

        public CartDetails GetCartDetailsById(Guid id)
        {
            return context.CartDetailss.FirstOrDefault(c=>c.UserID==id);
        }

        public List<CartDetails> GetCartDetailssByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetails(CartDetails p)
        {
            try
            {
                var a = context.CartDetailss.Find(p.ID);
                a.UserID=p.UserID;
                a.IDSP=p.IDSP;
                a.Quantity= p.Quantity;
                context.CartDetailss.Update(a);
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
