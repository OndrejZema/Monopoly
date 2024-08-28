using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monopoly.NewDAL.Migrations
{
    /// <inheritdoc />
    public partial class Zk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_card_type_Users_UserId",
                table: "card_type");

            migrationBuilder.DropForeignKey(
                name: "FK_field_type_Users_UserId",
                table: "field_type");

            migrationBuilder.DropIndex(
                name: "IX_field_type_UserId",
                table: "field_type");

            migrationBuilder.DropIndex(
                name: "IX_card_type_UserId",
                table: "card_type");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "field_type");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "card_type");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "field_type",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "card_type",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_field_type_UserId",
                table: "field_type",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_card_type_UserId",
                table: "card_type",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_card_type_Users_UserId",
                table: "card_type",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_field_type_Users_UserId",
                table: "field_type",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
