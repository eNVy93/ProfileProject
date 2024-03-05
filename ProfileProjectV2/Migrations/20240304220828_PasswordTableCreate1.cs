using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileProjectV2.Migrations
{
    /// <inheritdoc />
    public partial class PasswordTableCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPasswordInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", false),
                    PasswordSalt = table.Column<string>(type: "TEXT", nullable: false),
                    HashAlgorithm = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswordInfo", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPasswordInfo");
        }
    }
}
