namespace Shopping_Web_thien.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public string recipientName { get; set; }   
		public string recipientAddress { get; set; }
		public string recipientPhone{ get; set; }
		public virtual IQueryable<BillDetails> Detail { get; set; }
        public virtual User User { get; set; }
    }
}
