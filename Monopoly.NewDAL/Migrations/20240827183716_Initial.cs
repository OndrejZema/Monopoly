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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "card_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_card_type_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "field_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_field_type_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_completed = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                    table.ForeignKey(
                        name: "FK_banknote_game_game_id",
                        column: x => x.game_id,
                        principalTable: "game",
                        principalColumn: "id");
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
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                    table.ForeignKey(
                        name: "FK_card_card_type_card_type_id",
                        column: x => x.card_type_id,
                        principalTable: "card_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_card_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field", x => x.id);
                    table.ForeignKey(
                        name: "FK_field_field_type_field_type_id",
                        column: x => x.field_type_id,
                        principalTable: "field_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_field_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banknote_game_id",
                table: "banknote",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_banknote_id",
                table: "banknote",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_card_type_id",
                table: "card",
                column: "card_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_GameId",
                table: "card",
                column: "GameId");

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
                name: "IX_card_type_UserId",
                table: "card_type",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_field_field_type_id",
                table: "field",
                column: "field_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_field_GameId",
                table: "field",
                column: "GameId");

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
                name: "IX_field_type_UserId",
                table: "field_type",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_game_id",
                table: "game",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_game_UserId",
                table: "game",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banknote");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "field");

            migrationBuilder.DropTable(
                name: "card_type");

            migrationBuilder.DropTable(
                name: "field_type");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
