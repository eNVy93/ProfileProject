using CSVParser;
using Microsoft.EntityFrameworkCore;
using ProfileProjectV2.Model;
using ProfileProjectV2.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileProjectV2
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<UserPasswordInfo> UserPasswordInfo { get; set; }
        public DbSet<SwedbankStatement> SwedbankStatements { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "projectv1.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
