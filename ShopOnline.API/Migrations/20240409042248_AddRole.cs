using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Password", "Role", "SecurityStamp" },
                values: new object[] { "b65f4c70-7c10-4da9-86d7-9f1a2e8c0e2f", "$2a$11$nfcyHcAQ2TttLW5RXAqZPOWBOmFM.YavOFxDYrGphd9jVm/.wterS", 0, "c967389a-51e1-432a-9c5f-817637e6a4cf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Password", "Role", "SecurityStamp" },
                values: new object[] { "f41bb1a3-cef5-4318-9fb6-c06e23f47b29", "$2a$11$yAYGWwVe9PB9HQ3GlDf8ue01eHo9YmJRxCPGysryW/WrjeD5wX58i", 0, "98678bdf-e713-4cae-ac6a-8ff9eafaf9f3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "f270a940-929b-49e3-9cd8-c13f4d88d146", "$2a$11$ezZaerUvxeJVjHiyM23jS.U7xqD6IwOMFvGWy9uV.txD5kNr94KAq", "f48a201e-f3b8-4419-b36c-db34a1deb2e8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Password", "SecurityStamp" },
                values: new object[] { "f02d9ca2-84db-446e-9b70-507c4dd02221", "$2a$11$42MSivE/2SorqEs.wcgRYe9noEoiJfNIbX08uAdB/8iByVTmQWR72", "56568e7f-c12f-4bb6-82ec-e65d2d49cc84" });
        }
    }
}
