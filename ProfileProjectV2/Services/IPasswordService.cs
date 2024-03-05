using ProfileProjectV2.Model;

namespace ProfileProjectV2.Services
{
    public interface IPasswordService
    {
        string HashPasword(string password, out byte[] salt);
        void InsertPasswordInfo(UserPasswordInfo passwordInfo);
        bool VerifyPassword(string password, string hash, byte[] salt);
    }
}