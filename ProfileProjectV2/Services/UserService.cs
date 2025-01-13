using Microsoft.EntityFrameworkCore;
using ProfileProjectV2.Model;
using ProfileProjectV2.Model.User;
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
        public async Task CreateUserAsync(UserEntity user)
        {
            try
            {
                // TODO transaction begin
                var passwordHash = Task.Run(() => _passwordService.HashPasword(user.Password));
                user.PasswordHash = passwordHash.Result.Hash;
                //TODO do not save plain text password to database
                user.CreatedAt = DateTime.Now;
                _dbContext.Users.Add(user);
                _ = await _dbContext.SaveChangesAsync();
                string saltBase64 = Convert.ToBase64String(passwordHash.Result.Salt);

                await _passwordService.InsertPasswordInfoAsync(new UserPasswordInfo(saltBase64, user.Id));
            }
            catch
            {
                // TODO Do something
            }
            // -- Transaction commit
        }

        // should make async?
        public async Task DeleteUserAsync(UserEntity user)
        {
            try
            {
                var existingUser = _dbContext.Users.FirstOrDefaultAsync<UserEntity>(u => u.Id == user.Id);
                // good idea for logging?
                if (existingUser == null)
                {
                    return;
                }

                _dbContext.Users.Remove(existingUser.Result);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO do something
            }
        }

        // should make async?
        public async Task<UserEntity> GetUserAsync(int userId) => await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        // should make async?
        public List<UserEntity> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        // should make async?
        public async Task UpdateUserAsync(UserEntity user)
        {
            try
            {
                // SingleOrDefault returns exception if more records found
                // Can I reuse GetuserAsync??
                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                // good idea for logging?
                if (existingUser == null)
                {
                    return;
                }

                _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                _ = await _dbContext.SaveChangesAsync();
            }
            catch
            {
                // TODO
                // throw?
            }
        }

        public void MarkAsDeleted(UserEntity user)
        {
            // using GetUserAsync would implement DRY pattern
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            // good idea for logging?
            if (existingUser == null)
            {
                return;
            }

            user.IsDeleted = true;

            _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            _dbContext.SaveChangesAsync();
        }

        // TODO should be in separate service?
        public bool LoginUser(UserEntity user)
        {
            try
            {
                UserEntity existingUser = _dbContext.Users.SingleOrDefault(u => u.Username == user.Username);

                if (existingUser == null)
                {
                    return false;
                }
                UserPasswordInfo passwordInfo = _dbContext.UserPasswordInfo.SingleOrDefault(psw => psw.UserId == existingUser.Id);

                if (passwordInfo == null)
                {
                    return false;
                }

                PasswordEntity passwordEntity = new PasswordEntity(existingUser.PasswordHash, Convert.FromBase64String(passwordInfo.PasswordSalt));

                if (!_passwordService.VerifyPassword(user.Password, passwordEntity))
                {
                    return false;
                }

                if (existingUser.UserState == UserState.LoggedIn)
                {
                    return false;
                }

                existingUser.UserState = UserState.LoggedIn;
                _dbContext.Attach(existingUser);
                _dbContext.Entry(existingUser).Property(r => r.UserState).IsModified = true;
                _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                //TODO
                return false;
            }
        }

        // TODO should be in separate service?
        public bool LogOutUser(UserEntity user)
        {
            UserEntity existingUser = _dbContext.Users.SingleOrDefault(u => u.Username == user.Username);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserState = UserState.LoggedOut;
            _dbContext.Attach(existingUser);
            _dbContext.Entry(existingUser).Property(r => r.UserState).IsModified = true;
            _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
