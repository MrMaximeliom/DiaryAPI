using DiaryAPI.Data;
using DiaryAPI.Models;
namespace DiaryAPI.Services
{
    public class UserService
    {
        readonly ApplicationDBContext Context = new();
        public List<User> GetUsers(int count)
        {
            return Context.Users.Take(count).ToList();

        }
        public bool CreateUser(User newUser)
        {
            bool isUserAdded = true;
            try
            {
                Context.Users.Add(newUser);


            }
            catch (Exception)
            {
                isUserAdded = false;
            }
            return isUserAdded;

        }

        public bool DeleteUser(int id)
        {
            User? user = Context.Users.Find(id);
            bool isDeleted = false;

            if(user != null)
            {
                Context.Users.Remove(user);
                isDeleted = true;


            }
            return isDeleted;
        }
        public User? GetUser(int id)
        {
            return Context.Users.Find(id);
        }
    }
}
