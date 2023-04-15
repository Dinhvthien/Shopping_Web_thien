namespace Shopping_Web_thien.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int avaliabaleQuantity { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string photo { get; set; }
        public virtual ICollection<BillDetails> Details { get; }
        public virtual ICollection<CartDetails> CartDetail { get; set; }
    }
}
