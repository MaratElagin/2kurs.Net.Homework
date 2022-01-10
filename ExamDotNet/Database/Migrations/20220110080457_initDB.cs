using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HitPoints", "Name" },
                values: new object[,]
                {
                    { 1, 12, 3, 4, 2, 2, 40, "Mage" },
                    { 2, 7, 3, 1, 1, 0, 13, "Lemure" },
                    { 3, 17, 4, 2, 12, 4, 136, "Abbot" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
