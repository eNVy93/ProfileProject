using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ProfileProjectV2.Model
{
    public class UserPasswordInfo
    {
        public string PasswordSalt { get; set; }
        [Key]
        public int UserId { get; set; }
        public string HashAlgorithm { get; set; } 

        public UserPasswordInfo(string passwordSalt, int userId)
        {
            PasswordSalt = passwordSalt;
            UserId = userId;
            HashAlgorithm = HashAlgorithmName.SHA512.Name;
        }

    }
}
