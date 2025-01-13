using ProfileProjectV2.Model;
using ProfileProjectV2.Model.User;

namespace ProfileProjectV2.Services
{
    public interface IPasswordService
    {
        PasswordEntity HashPasword(string password);
        Task InsertPasswordInfoAsync(UserPasswordInfo passwordInfo);
        bool VerifyPassword(string password, PasswordEntity passwordEntity);
    }
}