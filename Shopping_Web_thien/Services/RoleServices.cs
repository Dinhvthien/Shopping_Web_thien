using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class RoleServices : IRoleServices
    {
        ShopDbContext context;
        public RoleServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                context.Roles.Add(p);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var role = context.Roles.Find(id);
                context.Roles.Remove(role);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(p => p.RoleID == id);
        }

        public List<Role> GetRolesByName(string name)
        {
            return context.Roles.Where(p => p.RoleName == name).ToList();
        }

        public bool UpdateRole(Role p)
        {
            try
            {
                var role = context.Roles.Find(p.RoleID);
                role.RoleName = p.RoleName;
                role.Description = p.Description;
                role.Status = p.Status;
                context.Update(role);
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
