using ProfileProjectV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileProjectV2.Services
{
    public interface IUserService
    {
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        public User GetUser(int userId);
        public List<User> GetUsers();
        void MarkAsDeleted(User user);
        bool LoginUser(User user);
        bool LogOutUser(User user);
    }
}
