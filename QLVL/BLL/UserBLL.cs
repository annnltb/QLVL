using System.Collections.Generic;
using QLVL.DAL;
using QLVL.Entity;

namespace QLVL.BLL
{
    public class UserBLL
    {
        private UserDAL userDal;

        public UserBLL()
        {
            userDal = new UserDAL();
        }

        public List<User> GetAllUsers()
        {
            return userDal.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return userDal.GetUserById(userId);
        }

        public void AddUser(User user)
        {
            userDal.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            userDal.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            userDal.DeleteUser(userId);
        }
    }
}
