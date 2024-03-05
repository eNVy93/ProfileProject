using ProfileProjectV2.Model;
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

        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(KeySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                Iterations,
                HashAlgorithm,
                KeySize);
            return Convert.ToHexString(hash);
        }
        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, KeySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        // TODO Async
        // TODO improve, error handling and etc
        public void InsertPasswordInfo(UserPasswordInfo passwordInfo)
        {
            _dbContext.UserPasswordInfo.Add(passwordInfo);
            _dbContext.SaveChangesAsync();
        }
    }
}
