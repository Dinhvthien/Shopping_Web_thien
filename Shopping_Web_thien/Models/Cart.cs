namespace Shopping_Web_thien.Models
{
    public class Cart
    {
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public virtual List<CartDetails> CarDetail { get; set; }
        public virtual User User { get; set; }
    }
}
