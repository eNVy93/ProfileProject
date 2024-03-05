using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileProjectV2.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // for passig password input TEMP
        public string PasswordHash { get; set; } // Store hashed passwords
        public int? AvatarId { get; set; } // Foreign key for Avatar
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Avatar? Avatar { get; set; } // Navigation property
        public UserState UserState { get; set; } // Navigation property

        // Other properties and navigation properties (Items, Hobbies, FinancialEntries)
    }
}
