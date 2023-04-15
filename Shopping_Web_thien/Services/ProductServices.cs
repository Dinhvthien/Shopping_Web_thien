using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class ProductServices : IProductServices
    {
        ShopDbContext context;
        public ProductServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                context.Products.Add(p);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProductsShow()
        {
            return context.Products.ToList().Where(p=>p.avaliabaleQuantity>5&&p.Status>1).ToList();
        }

        public List<Product> GetAllProducts() 
        {
            return context.Products.ToList();
        }
            
        

        public List<Product> GetProducsByName(string name)
        {
            return context.Products.Where(p => p.Name == name).ToList();
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.Id);
                product.Name = p.Name;
                product.Supplier = p.Supplier;
                product.Price = p.Price;
                product.Description = p.Description;
                product.Status= p.Status;
                product.avaliabaleQuantity= p.avaliabaleQuantity;
                product.photo= p.photo;
                context.Update(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
