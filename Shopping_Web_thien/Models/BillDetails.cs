namespace Shopping_Web_thien.Models
{
    public class BillDetails
    {
        public Guid Id { get; set; }    
        public Guid IDHD { get; set; }
        public Guid IDSP { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
