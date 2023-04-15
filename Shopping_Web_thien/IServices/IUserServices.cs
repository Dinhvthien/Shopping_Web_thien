using Shopping_Web_thien.Models;

namespace Shopping_Web_thien.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User p);

        public bool UpdateUser(User p);
        public bool DeleteUser(Guid id);
        public User GetUserById(Guid id);
        public List<User> GetUsersByName(string name);
        public List<User> GetAllUsers();

        public User Account(string username, string password);
        }

    }

