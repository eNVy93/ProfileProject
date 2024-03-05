using Microsoft.EntityFrameworkCore;
using ProfileProjectV2.Model;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileProjectV2.Services
{
    public class UserService : IUserService
    {
        // For now I have only single DbContext
        // in the future it would be preferable
        // to separate them into their ow dbContexts.
        // But for now I'll work with single and keep the logic outside dbContext.
        public AppDbContext _dbContext { get; set; }
        public IPasswordService _passwordService { get; set; }
        public UserService(AppDbContext appDbContext, IPasswordService passwordService)
        {
            _dbContext = appDbContext;
            _passwordService = passwordService;
        }

        // TODO code is not DRY. maybe create a generic method to update database and re-use it.

        // should make async?
        public void CreateUser(User user)
        {
            var passwordHash = _passwordService.HashPasword(user.Password, out byte[] salt);
            user.PasswordHash = passwordHash;
            //TODO do not save plai text password to database
            user.CreatedAt = DateTime.Now;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            string saltBase64 = Convert.ToBase64String(salt);
            
            _passwordService.InsertPasswordInfo(new UserPasswordInfo(saltBase64, user.Id));

            // jeigu nori async _dbContext.SaveChangesAsync();
        }

        // should make async?
        public void DeleteUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault<User>(u => u.Id == user.Id);
            // good idea for logging?
            if (existingUser == null)
            {
                return;
            }

            _dbContext.Users.Remove(existingUser);
            _dbContext.SaveChanges();
        }

        // should make async?
        public User GetUser(int userId)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);
            return user;
        }

        // should make async?
        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        // should make async?
        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            // good idea for logging?
            if (existingUser == null)
            {
                return;
            }

            _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            _dbContext.SaveChanges();
        }

        public void MarkAsDeleted(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            // good idea for logging?
            if (existingUser == null)
            {
                return;
            }

            user.IsDeleted = true;

            _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            _dbContext.SaveChanges();
        }

        public bool LoginUser(User user)
        {
            User existingUser = _dbContext.Users.SingleOrDefault(u => u.Username == user.Username);

            if(existingUser == null)
            {
                return false;
            }
            UserPasswordInfo passwordInfo = _dbContext.UserPasswordInfo.SingleOrDefault(psw => psw.UserId == existingUser.Id);

            byte[] saltBytes = Convert.FromBase64String(passwordInfo.PasswordSalt);
            if (passwordInfo == null || !_passwordService.VerifyPassword(user.Password, existingUser.PasswordHash, saltBytes))
            {
                return false;
            }

            if(existingUser.UserState == UserState.LoggedIn)
            {
                return false;
            }

            existingUser.UserState = UserState.LoggedIn;
            _dbContext.Attach(existingUser);
            _dbContext.Entry(existingUser).Property(r => r.UserState).IsModified = true;
            _dbContext.SaveChanges();

            return true;
            // jeigu nori async _dbContext.SaveChangesAsync();
        }
    }
}
