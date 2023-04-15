using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;

namespace Shopping_Website.Services
{
    public class UserServices : IUserServices
    {
        ShopDbContext context;
	
		public UserServices()
        {
            context = new ShopDbContext();
          
        }



		public User Account(string username, string password)
		{
            return context.Users.ToList().FirstOrDefault(x => x.UserName == username && x.PassWord == password);
		}

		public bool CreateUser(User p)
        {
            try
            {
                context.Users.Add(p);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var Users = context.Users.Find(id);
                context.Users.Remove(Users);// add vao Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.FirstOrDefault(p => p.UserID == id);
        }

        public List<User> GetUsersByName(string name)
        {
            return context.Users.Where(p => p.UserName == name).ToList();
        }

        public bool UpdateUser(User p)
        {
            try
            {
                var user = context.Users.Find(p.UserID);
                user.UserName = p.UserName;
                user.RoleID= p.RoleID;
                user.Status= p.Status;
                user.PassWord= p.PassWord;
                context.Update(user);
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
