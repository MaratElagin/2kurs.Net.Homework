using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class changeDamageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Damage",
                table: "Monsters",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Damage",
                value: "1d4");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Damage",
                value: "1d4");

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Damage",
                value: "4d8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Damage",
                table: "Monsters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Damage",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Damage",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Damage",
                value: 12);
        }
    }
}
