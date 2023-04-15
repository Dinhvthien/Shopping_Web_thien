namespace Shopping_Web_thien.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public int Status { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
