using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiManager.Migrations
{
    public partial class seeddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, "Mozhdeh", "Peykari", "123", "mojpey" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 2, "Nasser", "Faraji", "456", "na3rfaraji" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
