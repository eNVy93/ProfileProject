using ProfileProjectV2.Model;
using ProfileProjectV2.Model.User;
using System.Security.Cryptography;
using System.Text;

namespace ProfileProjectV2.Services
{
    public class PasswordService : IPasswordService
    {

        const int KeySize = 64;
        const int Iterations = 350000;
        readonly HashAlgorithmName HashAlgorithm;

        public PasswordService(AppDbContext dbContext)
        {
            HashAlgorithm = HashAlgorithmName.SHA512;
            _dbContext = dbContext;
        }

        public AppDbContext _dbContext { get; set; }

        public PasswordEntity HashPasword(string password)
        {
            // todo trycatch?
            var salt = RandomNumberGenerator.GetBytes(KeySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                Iterations,
                HashAlgorithm,
                KeySize);
            return new PasswordEntity(Convert.ToHexString(hash), salt);
        }
        public bool VerifyPassword(string password, PasswordEntity passwordEntity)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, passwordEntity.Salt, Iterations, HashAlgorithm, KeySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(passwordEntity.Hash));
        }

        // TODO Async
        // TODO improve, error handling and etc
        public async Task InsertPasswordInfoAsync(UserPasswordInfo passwordInfo)
        {
            _dbContext.UserPasswordInfo.Add(passwordInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
