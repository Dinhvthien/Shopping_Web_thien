using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface IRoleServices
    {
        public bool CreateRole(Role p);
        public bool UpdateRole(Role p);
        public bool DeleteRole(Guid id);
        public Role GetRoleById(Guid id);
        public List<Role> GetRolesByName(string name);
        public List<Role> GetAllRoles();

    }
}
