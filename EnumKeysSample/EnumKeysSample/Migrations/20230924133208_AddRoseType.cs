using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnumKeysSample.Migrations
{
    /// <inheritdoc />
    public partial class AddRoseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WineTypes",
                columns: new[] { "Type", "Description", "Name" },
                values: new object[] { 3, null, "Rose" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WineTypes",
                keyColumn: "Type",
                keyValue: 3);
        }
    }
}
