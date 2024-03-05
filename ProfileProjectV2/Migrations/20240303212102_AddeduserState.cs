using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileProjectV2.Migrations
{
    /// <inheritdoc />
    public partial class AddeduserState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserState",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserState",
                table: "Users");
        }
    }
}
