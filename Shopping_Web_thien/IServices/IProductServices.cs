using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
            
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public Product GetProductById(Guid id);
        public List<Product> GetProducsByName(string name);
        public List<Product> GetAllProducts();
        public List<Product> GetAllProductsShow();


    }
}
