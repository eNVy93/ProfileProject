using ProfileProjectV2.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileProjectV2.Services
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserEntity user);
        public Task UpdateUserAsync(UserEntity user);
        public Task DeleteUserAsync(UserEntity user);
        public Task<UserEntity> GetUserAsync(int userId);
        public List<UserEntity> GetUsers();
        void MarkAsDeleted(UserEntity user);
        bool LoginUser(UserEntity user);
        bool LogOutUser(UserEntity user);
    }
}
