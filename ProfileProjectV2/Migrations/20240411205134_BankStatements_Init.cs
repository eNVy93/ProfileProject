using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileProjectV2.Migrations
{
    /// <inheritdoc />
    public partial class BankStatements_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SwedbankStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SomeProperty = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Beneficiary = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    DK = table.Column<string>(type: "TEXT", nullable: false),
                    RecordId = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CodeInIS = table.Column<string>(type: "TEXT", nullable: false),
                    ClientCode = table.Column<string>(type: "TEXT", nullable: false),
                    Originator = table.Column<string>(type: "TEXT", nullable: false),
                    BeneficiaryParty = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwedbankStatements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwedbankStatements_AccountNumber",
                table: "SwedbankStatements",
                column: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwedbankStatements");
        }
    }
}
