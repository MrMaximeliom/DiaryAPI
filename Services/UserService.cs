using DiaryAPI.Data;
using DiaryAPI.Models;
namespace DiaryAPI.Services
{
    public class UserService
    {
        readonly DBContext Context = new();
        public List<User> GetUsers()
        {
            return Context.Users.ToList();

        }
        public void CreateUser(User newUser)
        {
            Context.Users.Add(newUser); 

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
    }
}
