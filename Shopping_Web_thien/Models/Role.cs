namespace Shopping_Web_thien.Models
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
