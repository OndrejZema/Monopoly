using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monopoly.NewDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banknote",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<long>(type: "bigint", nullable: false),
                    count = table.Column<long>(type: "bigint", nullable: false),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banknote", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    card_type_id = table.Column<long>(type: "bigint", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "field",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field_type_id = table.Column<long>(type: "bigint", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "field_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_completed = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banknote_id",
                table: "banknote",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_id",
                table: "card",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_type_id",
                table: "card_type",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_field_id",
                table: "field",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_field_type_id",
                table: "field_type",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_game_id",
                table: "game",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banknote");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "card_type");

            migrationBuilder.DropTable(
                name: "field");

            migrationBuilder.DropTable(
                name: "field_type");

            migrationBuilder.DropTable(
                name: "game");
        }
    }
}
